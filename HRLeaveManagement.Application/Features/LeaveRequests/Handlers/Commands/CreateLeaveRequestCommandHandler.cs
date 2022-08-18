using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Responses;
using HRLeaveManagement.Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Contracts.Infrastructure;
using HRLeaveManagement.Application.Models;
using System;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository leaveRequestRepository;
        private readonly IEmailSender emailSender;
        private readonly IMapper mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IEmailSender emailSender, IMapper mapper)
        {
            this.leaveRequestRepository = leaveRequestRepository;
            this.emailSender = emailSender;
            this.mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDtoValidator(leaveRequestRepository);

            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);
            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Create Failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            var leaveRequest = mapper.Map<LeaveRequest>(request.LeaveRequestDto);
            leaveRequest = await leaveRequestRepository.Add(leaveRequest);

            response.Success = true;
            response.Message = "Create Successful";
            response.Id = leaveRequest.Id;

            var email = new Email
            {
                To = "employee@org.com",
                Body = $"Your leave request for {request.LeaveRequestDto.StartDate:D} to {request.LeaveRequestDto.EndDate:D} has been submitted successfully.",
                Subject = "Leave Request Submitted"
            };
            try
            {
                await emailSender.SendEmail(email);
            }
            catch (Exception e)
            {
                // TODO Log or handle error
            }

            return response;
        }
    }
}

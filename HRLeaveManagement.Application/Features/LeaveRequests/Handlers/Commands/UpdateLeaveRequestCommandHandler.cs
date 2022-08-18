using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Responses;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository leaveRequestRepository;
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IMapper mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            this.leaveRequestRepository = leaveRequestRepository;
            this.leaveTypeRepository = leaveTypeRepository;
            this.mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var leaveRequest = await leaveRequestRepository.Get(request.Id);
            if (request.LeaveRequestDto != null)
            {
                var validator = new UpdateLeaveRequestDtoValidator(leaveTypeRepository);

                var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);
                if (!validationResult.IsValid)
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                    response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                }

                mapper.Map(request.LeaveRequestDto, leaveRequest);
                await leaveRequestRepository.Update(leaveRequest);

                response.Success = true;
                response.Message = "Update Successful";
                response.Id = leaveRequest.Id;

            }
            else if (request.ChangeLeaveRequestApprovalDto != null)
            {
                await leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDto.Approved);
                response.Success = true;
                response.Message = "Change Approval Successful";
                response.Id = leaveRequest.Id;
            }
            return response;
        }
    }
}

using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveType.Validators;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Responses;
using System.Linq;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IMapper mapper;
        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            this.leaveTypeRepository = leaveTypeRepository;
            this.mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response;
            var validator = new CreateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);
            if (!validationResult.IsValid)
            {
                response = new BaseCommandResponse
                {
                    Success = false,
                    Message = "Create Failed",
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }
            else
            {
                var leaveType = mapper.Map<LeaveType>(request.LeaveTypeDto);
                leaveType = await leaveTypeRepository.Add(leaveType);
                response = new BaseCommandResponse
                {
                    Success = true,
                    Message = "Create Successful",
                    Id = leaveType.Id
                };
            }
            return response;
        }
    }
}

using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveType.Validators;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Responses;
using System.Linq;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IMapper mapper;

        public UpdateLeaveTypCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            this.leaveTypeRepository = leaveTypeRepository;
            this.mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response;
            var validator = new UpdateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);
            if (!validationResult.IsValid)
            {
                response = new BaseCommandResponse
                {
                    Success = false,
                    Message = "Update Failed",
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }
            else
            {
                var leaveType = await leaveTypeRepository.Get(request.LeaveTypeDto.Id);
                mapper.Map(request.LeaveTypeDto, leaveType);
                await leaveTypeRepository.Update(leaveType);
                response = new BaseCommandResponse
                {
                    Success = true,
                    Message = "Update Successful",
                    Id = leaveType.Id
                };
            }
            return response;
        }
    }
}

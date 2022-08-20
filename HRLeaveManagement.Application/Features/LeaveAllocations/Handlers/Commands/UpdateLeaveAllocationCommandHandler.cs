using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Responses;
using System.Linq;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, BaseCommandResponse>
    {
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IMapper mapper;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.leaveTypeRepository = leaveTypeRepository;
            this.mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response;
            var validator = new UpdateLeaveAllocationDtoValidator(leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);
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
                var leaveAllocation = await leaveAllocationRepository.Get(request.LeaveAllocationDto.Id);
                mapper.Map(request.LeaveAllocationDto, leaveAllocation);
                await leaveAllocationRepository.Update(leaveAllocation);
                response = new BaseCommandResponse
                {
                    Success = true,
                    Message = "Update Successful",
                    Id = leaveAllocation.Id
                };
            }
            return response;
        }
    }
}

using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Responses;
using System.Linq;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, BaseCommandResponse>
    {
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IMapper mapper;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.leaveTypeRepository = leaveTypeRepository;
            this.mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response;
            var validator = new CreateLeaveAllocationDtoValidator(leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);
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
                var leaveAllocation = mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);
                leaveAllocation = await leaveAllocationRepository.Add(leaveAllocation);
                response = new BaseCommandResponse
                {
                    Success = true,
                    Message = "Create Successful",
                    Id = leaveAllocation.Id
                };
            }
            return response;
        }
    }
}

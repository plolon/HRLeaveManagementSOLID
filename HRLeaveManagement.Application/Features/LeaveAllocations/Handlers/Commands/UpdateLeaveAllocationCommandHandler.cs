using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly IMapper mapper;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDtoValidator(leaveAllocationRepository);
            var result = await validator.ValidateAsync(request.LeaveAllocationDto);
            if (!result.IsValid)
                throw new System.Exception();   // TODO handle exception

            var leaveAllocation = await leaveAllocationRepository.Get(request.LeaveAllocationDto.Id);
            mapper.Map(request.LeaveAllocationDto, leaveAllocation);
            await leaveAllocationRepository.Update(leaveAllocation);
            return Unit.Value;
        }
    }
}

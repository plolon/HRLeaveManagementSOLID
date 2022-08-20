using AutoMapper;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Responses;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, BaseCommandResponse>
    {
        private readonly ILeaveAllocationRepository leaveAllocationtRepository;
        private readonly IMapper mapper;

        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationtRepository, IMapper mapper)
        {
            this.leaveAllocationtRepository = leaveAllocationtRepository;
            this.mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await leaveAllocationtRepository.Get(request.Id);
            if (leaveAllocation == null)
                throw new NotFoundException(nameof(LeaveAllocation), request.Id);

            await leaveAllocationtRepository.Delete(leaveAllocation);
            return new BaseCommandResponse
            {
                Success = true,
                Message = "Delete Successful",
            };
        }
    }
}
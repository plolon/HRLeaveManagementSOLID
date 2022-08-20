using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using HRLeaveManagement.Application.Responses;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class UpdateLeaveAllocationCommand :IRequest<BaseCommandResponse>
    {
        public UpdateLeaveAllocationDto LeaveAllocationDto { get; set; }
    }
}

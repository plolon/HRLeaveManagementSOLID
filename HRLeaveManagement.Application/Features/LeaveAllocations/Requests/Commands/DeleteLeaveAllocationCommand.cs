using HRLeaveManagement.Application.Responses;
using MediatR;
namespace HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class DeleteLeaveAllocationCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}

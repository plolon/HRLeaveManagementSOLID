using HRLeaveManagement.Application.Responses;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class DeleteLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}

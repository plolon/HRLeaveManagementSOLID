using HRLeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestDetailsRequest : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}

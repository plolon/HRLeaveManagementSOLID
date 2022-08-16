using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;
using System.Collections.Generic;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveRequestListRequest : IRequest<List<LeaveAllocationDto>>
    {
    }
}

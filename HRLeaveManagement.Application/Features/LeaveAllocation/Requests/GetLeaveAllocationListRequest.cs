using HRLeaveManagement.Application.DTOs;
using MediatR;
using System.Collections.Generic;

namespace HRLeaveManagement.Application.Features.LeaveAllocation.Requests
{
    public class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>>
    {
    }
}

using HRLeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;
using System.Collections.Generic;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Requests
{
    public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestListDto>>
    {
    }
}

using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HRLeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestDetailsRequestHandler : IRequestHandler<GetLeaveRequestDetailsRequest, LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository leaveRequestRepository;
        private readonly IMapper mapper;

        public GetLeaveRequestDetailsRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            this.leaveRequestRepository = leaveRequestRepository;
            this.mapper = mapper;
        }

        public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetailsRequest request, CancellationToken cancellationToken)
        {
            var results = await leaveRequestRepository.GetLeaveRequestWithDetails(request.Id);
            return mapper.Map<LeaveRequestDto>(results);
        }
    }
}

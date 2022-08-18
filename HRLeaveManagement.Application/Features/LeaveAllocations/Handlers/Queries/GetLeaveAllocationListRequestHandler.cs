using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using HRLeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveRequestListRequestHandler : IRequestHandler<GetLeaveRequestListRequest, List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly IMapper mapper;

        public GetLeaveRequestListRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.mapper = mapper;
        }

        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
        {
            var results = await leaveAllocationRepository.GetAll();
            return mapper.Map<List<LeaveAllocationDto>>(results);
        }
    }
}

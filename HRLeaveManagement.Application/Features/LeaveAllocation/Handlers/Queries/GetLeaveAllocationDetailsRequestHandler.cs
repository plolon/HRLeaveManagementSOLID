using AutoMapper;
using HRLeaveManagement.Application.DTOs;
using HRLeaveManagement.Application.Features.LeaveAllocation.Requests;
using HRLeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveAllocation.Handlers.Queries
{
    public class GetLeaveAllocationDetailsRequestHandler : IRequestHandler<GetLeaveAllocationDetailsRequest, LeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly IMapper mapper;

        public GetLeaveAllocationDetailsRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.mapper = mapper;
        }

        public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationDetailsRequest request, CancellationToken cancellationToken)
        {
            var results = await leaveAllocationRepository.Get(request.Id);
            return mapper.Map<LeaveAllocationDto>(results);
        }
    }
}

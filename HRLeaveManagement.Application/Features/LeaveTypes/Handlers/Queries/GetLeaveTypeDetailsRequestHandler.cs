using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HRLeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeDetailsRequestHandler : IRequestHandler<GetLeaveTypeDetailsRequest, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IMapper mapper;
        public GetLeaveTypeDetailsRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            this.leaveTypeRepository = leaveTypeRepository;
            this.mapper = mapper;
        }
        public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailsRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await leaveTypeRepository.Get(request.Id);
            return mapper.Map<LeaveTypeDto>(leaveType);
        }
    }
}

using AutoMapper;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Responses;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository leaveRequestRepository;
        private readonly IMapper mapper;

        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            this.leaveRequestRepository = leaveRequestRepository;
            this.mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await leaveRequestRepository.Get(request.Id);
            if(leaveRequest == null)
                throw new NotFoundException(nameof(LeaveRequest), request.Id);

            await leaveRequestRepository.Delete(leaveRequest);
            return new BaseCommandResponse
            {
                Success = true,
                Message = "Delete Successful",
            };
        }
    }
}

using AutoMapper;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Responses;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IMapper mapper;
        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            this.leaveTypeRepository = leaveTypeRepository;
            this.mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await leaveTypeRepository.Get(request.Id);
            if (leaveType == null)
                throw new NotFoundException(nameof(LeaveType), request.Id);

            await leaveTypeRepository.Delete(leaveType);
            return new BaseCommandResponse
            {
                Success = true,
                Message = "Delete Successful",
            };
        }
    }
}

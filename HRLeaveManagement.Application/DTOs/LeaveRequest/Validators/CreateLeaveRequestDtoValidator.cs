using FluentValidation;
using HRLeaveManagement.Application.Persistence.Contracts;

namespace HRLeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveRequestRepository leaveRequestRepository;

        public CreateLeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            Include(new ILeaveRequestDtoValidator(leaveRequestRepository));
        }
    }
}

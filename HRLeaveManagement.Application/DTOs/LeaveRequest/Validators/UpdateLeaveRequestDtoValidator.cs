using FluentValidation;
using HRLeaveManagement.Application.Contracts.Persistence;

namespace HRLeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDtoValidator :AbstractValidator<UpdateLeaveRequestDto>
    {
        public UpdateLeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            Include(new ILeaveRequestDtoValidator(leaveRequestRepository));

            RuleFor(x => x.Id)
                .NotNull().WithMessage("{PropertyName must be present.}");
        }
    }
}

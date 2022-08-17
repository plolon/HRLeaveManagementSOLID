using FluentValidation;
using HRLeaveManagement.Application.Persistence.Contracts;

namespace HRLeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveRequestRepository leaveRequestRepository;

        public ILeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            this.leaveRequestRepository = leaveRequestRepository;
            RuleFor(x => x.StartDate)
                .LessThan(x => x.EndDate)
                .WithMessage("{PropertyName} must be before {ComparsionValue}.");
            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate)
                .WithMessage("{PropertyName} must be after {ComparsionValue}.");
            RuleFor(x => x.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var result = await leaveRequestRepository.Exists(id);
                    return !result;
                }).WithMessage("{PropertyName does not exist.}");
        }
    }
}

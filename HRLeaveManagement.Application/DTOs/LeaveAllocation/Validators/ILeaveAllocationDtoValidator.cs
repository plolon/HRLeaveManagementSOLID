using FluentValidation;
using HRLeaveManagement.Application.Contracts.Persistence;

namespace HRLeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        public ILeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {
            RuleFor(x => x.NumberOfDays)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.")
                .LessThan(100).WithMessage("{PropertyName} must be less than 100.");

            RuleFor(x => x.Period)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.")
                .LessThan(100).WithMessage("{PropertyName} must be less than 100.");

            RuleFor(x => x.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var result = await leaveAllocationRepository.Exists(id);
                    return !result;
                }).WithMessage("{PropertyName does not exist.}");
        }
    }
}

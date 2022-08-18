using FluentValidation;
using HRLeaveManagement.Application.Contracts.Persistence;

namespace HRLeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        public CreateLeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {
            Include(new ILeaveAllocationDtoValidator(leaveAllocationRepository));
        }
    }
}

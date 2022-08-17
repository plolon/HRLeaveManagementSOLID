using FluentValidation;
using HRLeaveManagement.Application.Persistence.Contracts;

namespace HRLeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        public CreateLeaveRequestDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {
            Include(new ILeaveAllocationDtoValidator(leaveAllocationRepository));
        }
    }
}

using HRLeaveManagement.Application.DTOs.Common;

namespace HRLeaveManagement.Application.DTOs
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int leaveTypeId { get; set; }
        public int Period { get; set; }
    }
}

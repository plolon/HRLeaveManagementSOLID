namespace HRLeaveManagement.Application.DTOs.LeaveAllocation
{
    public class CreateLeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public int leaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
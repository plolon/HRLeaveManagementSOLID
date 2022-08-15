using HRLeaveManagement.Domain.Common;
using System;

namespace HRLeaveManagement.Domain
{
    public class LeaveAllocation : BaseDomainEntity
    {
        public int NumberOfDays { get; set; }
        public LeaveType LeaveType { get; set; }
        public int leaveTypeId { get; set; }
        public int Period { get; set; }
    }
}

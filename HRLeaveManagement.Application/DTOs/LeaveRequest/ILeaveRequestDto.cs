﻿using System;

namespace HRLeaveManagement.Application.DTOs.LeaveRequest
{
    public interface ILeaveRequestDto
    {
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        int LeaveTypeId { get; set; }
        string RequestComments { get; set; }
    }
}

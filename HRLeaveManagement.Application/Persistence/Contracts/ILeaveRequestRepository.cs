using HRLeaveManagement.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approved);
    }
}
    
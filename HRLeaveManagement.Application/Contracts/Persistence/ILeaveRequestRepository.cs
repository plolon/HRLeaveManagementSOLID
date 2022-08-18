using HRLeaveManagement.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approved);
    }
}
    
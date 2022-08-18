using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext dbContext;

        public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext dbContext;

        public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

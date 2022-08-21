using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace HRLeaveManagement.Application.UnitTests.Mocs
{
    public static class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeMockedRepository()
        {
            var leaveTypes = new List<LeaveType>
            {
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Test Vacation"
                },
                new LeaveType
                {
                    Id = 2,
                    DefaultDays = 12,
                    Name = "Test Sick"
                }
            };
            var mockRepo = new Mock<ILeaveTypeRepository>();

            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(leaveTypes);
            mockRepo.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return leaveTypes.FirstOrDefault(x => x.Id.Equals(id));
            });
            mockRepo.Setup(x => x.Add(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveType) =>
            {
                leaveTypes.Add(leaveType);
                return leaveType;
            });
            mockRepo.Setup(x => x.Delete(It.IsAny<LeaveType>())).Verifiable();
            mockRepo.Setup(x => x.Update(It.IsAny<LeaveType>())).Verifiable();
            return mockRepo;
        }
    }
}

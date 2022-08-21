using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Profiles;
using HRLeaveManagement.Application.UnitTests.Mocs;
using Moq;

namespace HRLeaveManagement.Application.UnitTests.LeaveTypes
{
    public abstract class GenericLeaveTypeTests
    {
        protected readonly IMapper mapper;
        protected readonly Mock<ILeaveTypeRepository> mockRepo;

        public GenericLeaveTypeTests()
        {
            mockRepo = MockLeaveTypeRepository.GetLeaveTypeMockedRepository();

            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
            });

            mapper = mapperConfig.CreateMapper();
        }
    }
}

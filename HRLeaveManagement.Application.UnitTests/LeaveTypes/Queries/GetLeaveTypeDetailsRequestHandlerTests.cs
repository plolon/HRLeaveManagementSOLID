using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HRLeaveManagement.Application.Profiles;
using HRLeaveManagement.Application.UnitTests.Mocs;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HRLeaveManagement.Application.UnitTests.LeaveTypes.Queries
{
    public class GetLeaveTypeDetailsRequestHandlerTests
    {
        private readonly IMapper mapper;
        private readonly Mock<ILeaveTypeRepository> mockRepo;

        public GetLeaveTypeDetailsRequestHandlerTests()
        {
            mockRepo = MockLeaveTypeRepository.GetLeaveTypeMockedRepository();

            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
            });

            mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Valid_GetLeaveTypeDetailsTest()
        {
            var handler = new GetLeaveTypeDetailsRequestHandler(mockRepo.Object, mapper);

            var result = await handler.Handle(new GetLeaveTypeDetailsRequest {Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<LeaveTypeDto>();
            result.Id.ShouldBe(1);
        }
        [Fact]
        public async Task InValid_GetLeaveTypeDetailsTest()
        {
            var handler = new GetLeaveTypeDetailsRequestHandler(mockRepo.Object, mapper);

            var result = await handler.Handle(new GetLeaveTypeDetailsRequest { Id = 10 }, CancellationToken.None);

            result.ShouldBe(null);
        }
    }
}

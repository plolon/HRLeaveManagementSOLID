using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HRLeaveManagement.Application.Profiles;
using HRLeaveManagement.Application.UnitTests.Mocs;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HRLeaveManagement.Application.UnitTests.LeaveTypes.Queries
{
    public class GetLeaveTypeListRequestHandlerTests
    {
        private readonly IMapper mapper;
        private readonly Mock<ILeaveTypeRepository> mockRepo;

        public GetLeaveTypeListRequestHandlerTests()
        {
            mockRepo = MockLeaveTypeRepository.GetLeaveTypeMockedRepository();

            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
            });

            mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypeListRequestHandler(mockRepo.Object, mapper);

            var result = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveTypeDto>>();
            result.Count.ShouldBe(2);
        }

    }
}

using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HRLeaveManagement.Application.UnitTests.LeaveTypes.Queries
{
    public class GetLeaveTypeDetailsRequestHandlerTests : GenericLeaveTypeTests
    {
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

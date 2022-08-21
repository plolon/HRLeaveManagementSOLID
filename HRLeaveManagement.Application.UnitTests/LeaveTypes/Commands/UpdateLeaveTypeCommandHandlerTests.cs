using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Responses;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HRLeaveManagement.Application.UnitTests.LeaveTypes.Commands
{
    public class UpdateLeaveTypeCommandHandlerTests : GenericLeaveTypeTests
    {
        [Fact]
        public async Task Valid_LeaveTypeUpdate()
        {
            var handler = new UpdateLeaveTypCommandHandler(mockRepo.Object, mapper);

            var result = await handler.Handle(new UpdateLeaveTypeCommand
            {
                LeaveTypeDto = new LeaveTypeDto
                {
                    Id = 1,
                    Name = "Test name",
                    DefaultDays = 40
                }
            }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Errors.ShouldBeNull();
            result.Success.ShouldBeTrue();
            result.Message.ShouldBe("Update Successful");
        }
    }
}

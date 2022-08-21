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
    public class CreateLeaveTypeCommandHandlerTests : GenericLeaveTypeTests
    {
        [Fact]
        public async Task Valid_LeaveTypeAdded()
        {
            var handler = new CreateLeaveTypeCommandHandler(mockRepo.Object, mapper);

            var result = await handler.Handle(new CreateLeaveTypeCommand
            {
                LeaveTypeDto = new CreateLeaveTypeDto
                {
                    Name = "Test name",
                    DefaultDays = 90
                }
            }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Errors.ShouldBeNull();
            result.Success.ShouldBeTrue();
            result.Message.ShouldBe("Create Successful");
        }

        [Fact]
        public async Task InValid_LeaveTypeAdded()
        {
            var handler = new CreateLeaveTypeCommandHandler(mockRepo.Object, mapper);

            var result = await handler.Handle(new CreateLeaveTypeCommand
            {
                LeaveTypeDto = new CreateLeaveTypeDto
                {
                    Name = "Test name",
                    DefaultDays = -10
                }
            }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Errors.ShouldNotBeNull();
            result.Success.ShouldBeFalse();
            result.Message.ShouldBe("Create Failed");
        }
    }
}

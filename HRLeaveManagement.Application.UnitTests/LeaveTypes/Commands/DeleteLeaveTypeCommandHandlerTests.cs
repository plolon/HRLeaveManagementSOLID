using HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Responses;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HRLeaveManagement.Application.UnitTests.LeaveTypes.Commands
{
    public class DeleteLeaveTypeCommandHandlerTests : GenericLeaveTypeTests
    {
        [Fact]
        public async Task Valid_LeaveTypeDelete()
        {
            var handler = new DeleteLeaveTypeCommandHandler(mockRepo.Object, mapper);

           var result =  await handler.Handle(new DeleteLeaveTypeCommand
            {
                Id = 1
            }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Errors.ShouldBeNull();
            result.Success.ShouldBeTrue();
            result.Message.ShouldBe("Delete Successful");
        }
    }
}

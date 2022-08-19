using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Profiles;
using HRLeaveManagement.Application.Responses;
using HRLeaveManagement.Application.UnitTests.Mocs;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HRLeaveManagement.Application.UnitTests.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandHandlerTests
    {
        private readonly IMapper mapper;
        private readonly Mock<ILeaveTypeRepository> mockRepo;

        public CreateLeaveTypeCommandHandlerTests()
        {
            mockRepo = MockLeaveTypeRepository.GetLeaveTypeMockedRepository();

            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
            });

            mapper = mapperConfig.CreateMapper();
        }

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

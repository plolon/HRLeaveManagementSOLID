using HRLeaveManagement.Application.DTOs.LeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HRLeaveManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRLeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly IMediator mediator;

        public LeaveRequestsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/<LeaveRequestsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDto>>> Get()
        {
            var leaveRequests = await mediator.Send(new GetLeaveRequestListRequest());
            return Ok(leaveRequests);
        }

        // GET api/<LeaveRequestsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> Get(int id)
        {
            var leaveRequest = await mediator.Send(new GetLeaveRequestDetailsRequest());
            return Ok(leaveRequest);
        }

        // POST api/<LeaveRequestsController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveRequestDto createLeaveRequestDto)
        {
            var response = await mediator.Send(new CreateLeaveRequestCommand { LeaveRequestDto = createLeaveRequestDto });
            return Ok(response);
        }

        // PUT api/<LeaveRequestsController>
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put(int id, [FromBody] UpdateLeaveRequestDto updateLeaveRequestDto)
        {
            var response = await mediator.Send(new UpdateLeaveRequestCommand { Id = id, LeaveRequestDto = updateLeaveRequestDto });
            return Ok(response);
        }
        // PUT api/<LeaveRequestsController>/changeapproval/5
        [HttpPut("changeapproval/{id}")]
        public async Task<ActionResult<BaseCommandResponse>> ChangeApproval(int id, [FromBody] ChangeLeaveRequestApprovalDto changeLeaveRequestApprovalDto)
        {
            var response = await mediator.Send(new UpdateLeaveRequestCommand { Id = id, ChangeLeaveRequestApprovalDto = changeLeaveRequestApprovalDto });
            return Ok(response);
        }
        // DELETE api/<LeaveRequestsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var response = await mediator.Send(new DeleteLeaveRequestCommand { Id = id });
            return Ok(response);
        }
    }
}

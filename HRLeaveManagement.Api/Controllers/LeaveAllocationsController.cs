using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRLeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationsController : ControllerBase
    {
        private readonly IMediator mediator;

        public LeaveAllocationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/<LeaveAllocationsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
        {
            var leaveAllocations = await mediator.Send(new GetLeaveAllocationListRequest());
            return Ok(leaveAllocations);
        }

        // GET api/<LeaveAllocationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
        {
            var leaveAllocation = await mediator.Send(new GetLeaveAllocationDetailsRequest { Id = id});
            return Ok(leaveAllocation);
        }

        // POST api/<LeaveAllocationsController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateLeaveAllocationDto createLeaveAllocationDto)
        {
            var response = await mediator.Send(new CreateLeaveAllocationCommand { LeaveAllocationDto = createLeaveAllocationDto });
            return Ok(response);
        }

        // PUT api/<LeaveAllocationsController>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationDto updateLeaveAllocationDto)
        {
            await mediator.Send(new UpdateLeaveAllocationCommand { LeaveAllocationDto = updateLeaveAllocationDto });
            return NoContent();
        }

        // DELETE api/<LeaveAllocationsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await mediator.Send(new DeleteLeaveAllocationCommand { Id = id });
            return NoContent();
        }
    }
}

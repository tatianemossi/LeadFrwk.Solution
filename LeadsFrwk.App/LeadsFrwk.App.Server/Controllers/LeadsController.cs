using LeadsFrwk.Server.Domain.Commands.AddLeadCommand;
using LeadsFrwk.Server.Domain.Commands.DeleteLeadCommand;
using LeadsFrwk.Server.Domain.Entities;
using LeadsFrwk.Server.Domain.Queries.GetAllLeadsQuery;
using LeadsFrwk.Server.Domain.Queries.GetByIdLeadQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LeadsFrwk.App.Server.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private IMediator _mediator;

        public LeadsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Lead?>> Get()
        {
            return await _mediator.Send(new GetAllLeadsQuery());
        }

        [HttpGet("{id}")]
        public async Task<Lead?> Get(int id)
        {
            return await _mediator.Send(new GetByIdLeadQuery(id));
        }

        [HttpPost]
        public async Task<StatusCodeResult> Post([FromBody] AddLeadCommand command)
        {
            var success = await _mediator.Send(command);
            if (success)
                return Ok();
            return BadRequest();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public async Task<StatusCodeResult> Delete(int id)
        {
            var success = await _mediator.Send(new DeleteLeadCommand(id));
            if (success)
                return Ok();
            return NoContent();
        }
    }
}

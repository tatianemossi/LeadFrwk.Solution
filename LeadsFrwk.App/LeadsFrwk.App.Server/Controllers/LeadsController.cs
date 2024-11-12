using LeadsFrwk.Server.Domain.Commands.AcceptedLeadCommand;
using LeadsFrwk.Server.Domain.Commands.AddLeadCommand;
using LeadsFrwk.Server.Domain.Commands.DeleteLeadCommand;
using LeadsFrwk.Server.Domain.Commands.SendMailAcceptedCommand;
using LeadsFrwk.Server.Domain.Entities;
using LeadsFrwk.Server.Domain.LeadChangeStatus;
using LeadsFrwk.Server.Domain.Queries.GetAllLeadsQuery;
using LeadsFrwk.Server.Domain.Queries.GetByIdLeadQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
            var result = await _mediator.Send(new GetAllLeadsQuery());
            return result;
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
        public async Task<IActionResult> ChangeStatusLead(int id, [FromBody] LeadChangeStatusRequestModel body)
        {
            try
            {
                var message = string.Empty;

                var success = await _mediator.Send(new ChangeStatusLeadCommand(id, body.Status, body.Price));
                if (success)
                {
                    message = "Status changed successfully!";

                    var mailSent = await _mediator.Send(new SendMailAcceptedCommand(id, body.Email));
                    if (mailSent)
                        message += "\n E-mail sent successfully!";
                }
                else
                    message = "Status has not changed, please try again or contact to support!";

                return Ok(new { message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message});
            }
        }

        [HttpDelete("{id}")]
        public async Task<StatusCodeResult> Delete(int id)
        {
            var success = await _mediator.Send(new DeleteLeadCommand(id));
            if (success)
                return Ok();
            return BadRequest();
        }
    }
}

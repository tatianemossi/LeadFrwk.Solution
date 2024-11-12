using LeadsFrwk.Server.Domain.Interfaces.Services;
using MediatR;

namespace LeadsFrwk.Server.Domain.Commands.AcceptedLeadCommand
{
    public class ChangeStatusLeadCommandHandler : IRequestHandler<ChangeStatusLeadCommand, bool>
    {
        private readonly ILeadService _leadService;

        public ChangeStatusLeadCommandHandler(ILeadService leadService)
        {
            _leadService = leadService;
        }

        public async Task<bool> Handle(ChangeStatusLeadCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var lead = await _leadService.GetByIdAsync(request.Id, cancellationToken);

                if (lead is null)
                    return false;

                lead.Status = request.Status;
                lead.Price = _leadService.CalculateDiscaunt(request, lead.Price, lead.Status);

                var result = await _leadService.UpdateAsync(lead, cancellationToken);

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

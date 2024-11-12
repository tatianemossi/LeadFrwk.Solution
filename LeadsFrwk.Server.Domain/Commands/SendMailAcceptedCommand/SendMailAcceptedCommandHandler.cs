using LeadsFrwk.Server.Domain.Commands.AcceptedLeadCommand;
using LeadsFrwk.Server.Domain.Enums;
using LeadsFrwk.Server.Domain.Interfaces.Services;
using MediatR;

namespace LeadsFrwk.Server.Domain.Commands.SendMailAcceptedCommand
{
    public class SendMailAcceptedCommandHandler : IRequestHandler<SendMailAcceptedCommand, bool>
    {
        private readonly ILeadService _leadService;

        public SendMailAcceptedCommandHandler(ILeadService leadService)
        {
            _leadService = leadService;
        }

        public async Task<bool> Handle(SendMailAcceptedCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sucesso = await _leadService.SendMailAsync(request.Id, request.Email, cancellationToken);

                if (sucesso)
                    return true;

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

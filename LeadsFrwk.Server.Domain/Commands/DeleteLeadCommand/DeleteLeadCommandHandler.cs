using LeadsFrwk.Server.Domain.Interfaces.Services;
using MediatR;

namespace LeadsFrwk.Server.Domain.Commands.DeleteLeadCommand
{
    public class DeleteLeadCommandHandler : IRequestHandler<DeleteLeadCommand, bool>
    {
        private readonly ILeadService _leadService;

        public DeleteLeadCommandHandler(ILeadService leadService)
        {
            _leadService = leadService;
        }

        public async Task<bool> Handle(DeleteLeadCommand request, CancellationToken cancellationToken)
        {
            return await _leadService.DeleteAsync(request.Id, cancellationToken);
        }
    }
}

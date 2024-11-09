using LeadsFrwk.Server.Domain.Entities;
using LeadsFrwk.Server.Domain.Interfaces.Services;
using MediatR;

namespace LeadsFrwk.Server.Domain.Queries.GetByIdLeadQuery
{
    public class GetByIdLeadQueryHandler : IRequestHandler<GetByIdLeadQuery, Lead?>
    {
        private readonly ILeadService _leadService;

        public GetByIdLeadQueryHandler(ILeadService leadService)
        {
            _leadService = leadService;
        }

        public async Task<Lead?> Handle(GetByIdLeadQuery request, CancellationToken cancellationToken)
        {
            return await _leadService.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}

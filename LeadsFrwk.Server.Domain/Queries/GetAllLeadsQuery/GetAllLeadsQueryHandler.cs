using LeadsFrwk.Server.Domain.Entities;
using LeadsFrwk.Server.Domain.Interfaces.Services;
using MediatR;

namespace LeadsFrwk.Server.Domain.Queries.GetAllLeadsQuery
{
    public class GetAllLeadsQueryHandler : IRequestHandler<GetAllLeadsQuery, IEnumerable<Lead?>>
    {
        private readonly ILeadService _leadService;

        public GetAllLeadsQueryHandler(ILeadService leadService)
        {
            _leadService = leadService;
        }

        public async Task<IEnumerable<Lead?>> Handle(GetAllLeadsQuery request, CancellationToken cancellationToken)
        {
            return await _leadService.GetAllAsync(cancellationToken);
        }
    }
}

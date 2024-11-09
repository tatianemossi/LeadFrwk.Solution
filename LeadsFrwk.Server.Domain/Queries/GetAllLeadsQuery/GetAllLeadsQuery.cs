using LeadsFrwk.Server.Domain.Entities;
using MediatR;

namespace LeadsFrwk.Server.Domain.Queries.GetAllLeadsQuery
{
    public class GetAllLeadsQuery : IRequest<IEnumerable<Lead?>>
    {
    }
}

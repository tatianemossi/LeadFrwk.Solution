using LeadsFrwk.Server.Domain.Entities;
using MediatR;

namespace LeadsFrwk.Server.Domain.Queries.GetByIdLeadQuery
{
    public class GetByIdLeadQuery : IRequest<Lead?>
    {
        public GetByIdLeadQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

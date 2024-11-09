using LeadsFrwk.Server.Domain.Entities;
using LeadsFrwk.Server.Domain.Interfaces.Repositories;
using LeadsFrwk.Server.Infrastructure.Data;

namespace LeadsFrwk.Server.Infrastructure.Repository
{
    public class LeadRepository : Repository<Lead>, ILeadRepository
    {
        public LeadRepository(DatabaseContext dbContext) 
            : base(dbContext) { }
    }
}

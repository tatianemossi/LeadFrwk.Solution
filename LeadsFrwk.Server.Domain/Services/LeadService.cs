using LeadsFrwk.Server.Domain.Entities;
using LeadsFrwk.Server.Domain.Interfaces.Repositories;
using LeadsFrwk.Server.Domain.Interfaces.Services;

namespace LeadsFrwk.Server.Domain.Services
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;

        public LeadService(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<IEnumerable<Lead>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _leadRepository.GetAllAsync(cancellationToken);
        }

        public async Task<Lead?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _leadRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<Lead> AddAsync(Lead lead, CancellationToken cancellationToken)
        {
            return await _leadRepository.AddAsync(lead, cancellationToken);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var lead = await _leadRepository.GetByIdAsync(id, cancellationToken);

            if (lead is null) 
                return false;
            
            await _leadRepository.RemoveAsync(lead, cancellationToken);
            return true;
        }
    }
}

using LeadsFrwk.Server.Domain.Entities;

namespace LeadsFrwk.Server.Domain.Interfaces.Services
{
    public interface ILeadService 
    {
        Task<Lead> AddAsync(Lead lead, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(Lead lead, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Lead>> GetAllAsync(CancellationToken cancellationToken);
        Task<Lead?> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}
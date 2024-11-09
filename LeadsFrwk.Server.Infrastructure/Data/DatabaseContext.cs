using LeadsFrwk.Server.Domain.Entities;
using LeadsFrwk.Server.Infrastructure.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace LeadsFrwk.Server.Infrastructure.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) { }

        public DbSet<Lead>? Leads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LeadMap());
        }
    }
}
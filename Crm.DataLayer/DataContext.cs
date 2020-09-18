using Crm.DataLayer;
using Crm.DataLayer.EntityConfigurations;
using Crm.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Crm.DataLayer
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<LeadSource> LeadSource { get; set; }
        public DbSet<LeadStatus> LeadStatus { get; set; }
        public DbSet<QualifyQuestion> QualifyQuestion { get; set; }
        public DbSet<QualifyQuestionAnswers> QualifyQuestionAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new LeadSourceConfiguration());
            modelBuilder.ApplyConfiguration(new LeadStatusConfiguration());

        }
    }
}

using AccountErp.DataLayer.EntityConfigurations;
using AccountErp.Entities;
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
        public DbSet<Lead> Lead { get; set; }
        public DbSet<ActivityCall> ActivityCall { get; set; }
        public DbSet<ActivityMeeting> ActivityMeeting { get; set; }
        public DbSet<ActivityNotes> ActivityNotes { get; set; }
        public DbSet<UserScreenAccess> UserScreenAccess { get; set; }
        public DbSet<ScreenDetail> ScreenDetail { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new LeadSourceConfiguration());
            modelBuilder.ApplyConfiguration(new LeadStatusConfiguration());
            modelBuilder.ApplyConfiguration(new QualifyQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new QualifyQuestionAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new LeadConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityCallConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityMeetingConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityNotesConfiguration());
            modelBuilder.ApplyConfiguration(new UserScreenAccessConfiguration());
            modelBuilder.ApplyConfiguration(new ScreenDetailConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new StateConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

        }
    }
}

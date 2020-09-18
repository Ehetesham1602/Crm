using Crm.DataLayer;
using Crm.DataLayer.Repositories;
using Crm.Infrastructure.DataLayer;
using Crm.Infrastructure.Managers;
using Crm.Infrastructure.Repositories;
using Crm.Infrastructure.Services;
using Crm.Managers;
using Crm.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Config
{
    public class MiddlewareConfiguration
    {
        public static void ConfigureEf(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<DataContext>(
                    options => options.UseNpgsql(connectionString));
        }
        public static void ConfigureUow(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static void ConfigureManager(IServiceCollection services)
        {
            services.AddScoped<ISeedManager, SeedManager>();
            services.AddScoped<ILeadSourceManager, LeadSourceManager>();
            services.AddScoped<ILeadStatusManager, LeadStatusManager>();
            services.AddScoped<IQualifyQuestionManager, QualifyQuestionManager>();
        }
        public static void ConfigureRepository(IServiceCollection services)
        {
            services.AddScoped<ILeadSourceRepository, LeadSourceRepository>();
            services.AddScoped<ILeadStatusRepository, LeadStatusRepository>();
            services.AddScoped<IQualifyQuestionRepository, QualifyQuestionRepository>();

        }
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}

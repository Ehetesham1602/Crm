﻿using AccountErp.Infrastructure.Managers;
using AccountErp.Managers;
using AccountErp.Services;
using Crm.DataLayer;
using Crm.DataLayer.Repositories;
using Crm.Infrastructure.DataLayer;
using Crm.Infrastructure.Managers;
using Crm.Infrastructure.Repositories;
using Crm.Infrastructure.Services;
using Crm.Managers;
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
            services.AddScoped<ILeadManager, LeadManager>();
            services.AddScoped<IActivitiesManager, ActivitiesManager>();
            services.AddScoped<IUserAccessMAnager, UserAccessManager>();
            services.AddScoped<IMasterManager, MasterManager>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IUserRoleManager, UserRoleManager>();
            services.AddScoped<ILeadAssignManager, LeadAssignManager>();
            services.AddScoped<IDashBoardManager, DashBoardManager>();
            services.AddScoped<IEmailManager, EmailManager>();

        }
        public static void ConfigureRepository(IServiceCollection services)
        {
            services.AddScoped<ILeadSourceRepository, LeadSourceRepository>();
            services.AddScoped<ILeadStatusRepository, LeadStatusRepository>();
            services.AddScoped<IQualifyQuestionRepository, QualifyQuestionRepository>();
            services.AddScoped<ILeadRepository, LeadRepository>();
            services.AddScoped<IActivitiesRepository, ActivitiesRepository>();
            services.AddScoped<IUserAccessRepository, UserAccessRepository>();
            services.AddScoped<IMasterRepository, MasterRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<ILeadAssignRepository, LeadAssignRepository>();
            services.AddScoped<IDashBoardRepository, DashBoardRepository>();

        }
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IEmailServiceSendLeadAsync, EmailService>();
        }
    }
}

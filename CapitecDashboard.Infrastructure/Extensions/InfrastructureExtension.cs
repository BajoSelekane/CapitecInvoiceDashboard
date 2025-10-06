using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Interfaces;
using CapitecDashboard.Domain.Interfaces.Files;
using CapitecDashboard.Domain.Interfaces.Repositories;
using CapitecDashboard.Domain.Models.Request.Filters;
using CapitecDashboard.Domain.Services;
using CapitecDashboard.Domain.Utils;
using CapitecDashboard.Infrastructure.DbContexts;
using CapitecDashboard.Infrastructure.Files;
using CapitecDashboard.Infrastructure.Repositories;
using CapitecDashboard.Infrastructure.Repositories.BaseRepositories;
using CapitecDashboard.Infrastructure.Utils;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MimeKit.Utils;
using System.Diagnostics.Metrics;




namespace CapitecDashboard.Infrastructure.Extensions
{
    public static class InfrastructureExtension
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environments.Development}.json", optional: true, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddTransient<UserStore<User>>();
            services.AddDbContext<InvoiceDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddTransient<DbContext, InvoiceDbContext>();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddUtils();
            services.AddServices();
            services.AddCommandRepositories();
            services.AddQueryRepositories();

            return services;
        }

        private static IServiceCollection AddCommandRepositories(this IServiceCollection services)
        {
           
            services.AddTransient<ICommandRepository<ApplicationProperty>, CommandRepository<ApplicationProperty>>();
          
            services.AddTransient<ICommandRepository<Invoice>, CommandRepository<Invoice>>();
            //services.AddTransient<ICommandRepository<UserDetail>, CommandRepository<UserDetail>>();



            return services;
        }

        private static IServiceCollection AddQueryRepositories(this IServiceCollection services)
        {
         
           // services.AddTransient<IQueryRepository<ApplicationProperty, ApplicationPropertyFilter>, ApplicationPropertyQueryRepository>();
          
            services.AddTransient<IQueryRepository<AccessLevel, AccessLevelFilter>, AccessLevelQueryRepository>();
           // services.AddTransient<IQueryRepository<UserDetail, UserDetailFilter>>();


            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IReadFileService, ReadFileService>();

            return services;
        }

        private static IServiceCollection AddUtils(this IServiceCollection services)
        {

            services.AddTransient<ISerializer, Serializer>();
            //services.AddTransient<IDateUtil, DateUtil>();
            services.AddTransient<IBaseRestClient, BaseRestClient>();
            services.AddTransient<IEmailService, EmailService>();
            return services;
        }

        static IServiceCollection AddGeneralServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticateService, AuthenticateService>();
            services.AddScoped<IRoleService, RoleService>();

            return services;
        }

    }
}

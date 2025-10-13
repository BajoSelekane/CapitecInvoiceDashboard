using CapitecDashboard.Domain.Interfaces;
using CapitecDashboard.Domain.Interfaces.Files;
using CapitecDashboard.Domain.Interfaces.Services.CommandService;
using CapitecDashboard.Domain.Interfaces.Services.QueryService;
using CapitecDashboard.Domain.Services;
using CapitecDashboard.Domain.Services.CommandServices;
using CapitecDashboard.Domain.Services.QueryServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Extensions
{
    public static class DomainExtension
    {

        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddCommandServices();
            services.AddQueryServices();
            services.AddGeneralServices();

            return services;
        }
        static IServiceCollection AddCommandServices(this IServiceCollection services)
        {
          
            services.AddTransient<IAccessLevelCommandService, AccessLevelCommandService>();
           // services.AddTransient<IUserDetailCommandService, UserDetailCommandService>();
            services.AddTransient<IInvoiceCommandService, InvoiceCommandService>();


            return services;
        }
        static IServiceCollection AddQueryServices(this IServiceCollection services)
        {
           
            services.AddTransient<IAccessLevelQueryService, AccessLevelQueryService>();
           // services.AddTransient<IUserDetailQueryService, UserDetailQueryService>();
            services.AddTransient<IInvoiceQueryService, InvoiceQueryService>();


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

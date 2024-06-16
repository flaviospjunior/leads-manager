using Leads.Application.Services.EmailService;
using Leads.Data.Contexts;
using Leads.Data.Repositories;
using Leads.Domain.Aggregates.Lead;
using Leads.SharedKernel;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Leads.Application.IoC
{
    public static class IoC
    {

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddAplicationServices();
            services.AddDataServices();
            services.ConfigureKernel();

            return services;
        }

        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }

        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<LeadsDbContext>();
            services.AddScoped<ILeadRepository, LeadRepository>();

            return services;
        }

        private static IServiceCollection ConfigureKernel(this IServiceCollection services)
        {
            KernelIoc.RegisterSharedServices(services);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }

    }
}

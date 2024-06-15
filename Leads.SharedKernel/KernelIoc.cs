using Leads.SharedKernel.Mediator.Implementations;
using Leads.SharedKernel.Mediator.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Leads.SharedKernel
{
    public static class KernelIoc
    {
        public static void RegisterSharedServices(IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
        }
    }
}

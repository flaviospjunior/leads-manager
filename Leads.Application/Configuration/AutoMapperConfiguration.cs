using AutoMapper;
using Leads.Application.Features.Leads.Commands.ChangeLeadStatus;
using Leads.Application.Features.Leads.Queries.GetAllLeads;

namespace Leads.Application.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static IMapper ConfigureMapper()
        {
            return new MapperConfiguration(ConfigureProfiles).CreateMapper();
        }

        private static void ConfigureProfiles(IMapperConfigurationExpression config)
        {
            config.AddProfile<ChangeLeadStatusMapping>();
            config.AddProfile<GetAllLeadsMapping>();
        }
    }
}

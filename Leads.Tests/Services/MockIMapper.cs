using AutoMapper;
using Leads.Application.IoC;

namespace Leads.Tests.Services
{
    public class MockIMapper
    {
        public static IMapper GetMapper() => IoC.GetMapper();
    }
}

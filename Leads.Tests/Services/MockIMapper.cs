using AutoMapper;
using Leads.Application.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Tests.Services
{
    public class MockIMapper
    {
        public static IMapper GetMapper() => IoC.GetMapper();
    }
}

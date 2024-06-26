﻿using AutoMapper;
using Leads.Application.Services.EmailService;
using Leads.Tests.Services;
using MediatR;

namespace Leads.Tests.Fixture
{
    public class ServiceFixture : IDisposable
    {
        public IEmailService EmailService { get; private set; }
        public IMapper Mapper { get; private set; }
        public IMediator Mediator { get; private set; }
        public ServiceFixture()
        {
            EmailService = MockIEmailService.GetMock().Object;
            Mapper = MockIMapper.GetMapper();
            Mediator = MockIMediator.GetMock().Object;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

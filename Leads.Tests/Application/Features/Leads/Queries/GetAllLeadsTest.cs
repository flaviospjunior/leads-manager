﻿using Leads.Application.Features.Leads.Queries.GetAllLeads;
using Leads.Tests.Fixture;
using Xunit;

namespace Leads.Tests.Application.Features.Leads.Queries
{
    public class GetAllLeadsTest
    {
        private readonly FixtureSingleton _fixtureSingleton;

        public GetAllLeadsTest()
        {
            _fixtureSingleton = FixtureSingleton.Instance;
        }


        [Fact]
        public async Task GetAllLeads_Success()
        {
            var handler = new GetAllLeadsQueryHandler(_fixtureSingleton.DbFixture.LeadRepository, _fixtureSingleton.ServiceFixture.Mapper, _fixtureSingleton.ServiceFixture.Mediator);

            var result = await handler.Handle(new GetAllLeadsQuery(), CancellationToken.None);

            Assert.IsType<GetAllLeadsQueryResponse>(result);
            Assert.True(result.Success);
            Assert.True(result.Leads.Any());
            Assert.False(result.Errors.Any());

        }
    }
}

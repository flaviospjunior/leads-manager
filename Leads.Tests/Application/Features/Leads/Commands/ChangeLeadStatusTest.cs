using Leads.Application.Features.Leads.Commands.ChangeLeadStatus;
using Leads.Domain.Enums;
using Leads.Tests.Fixture;
using Xunit;

namespace Leads.Tests.Application.Features.Leads.Commands
{
    public class ChangeLeadStatusTest
    {
        private readonly FixtureSingleton _fixtureSingleton;

        public ChangeLeadStatusTest()
        {
            _fixtureSingleton = FixtureSingleton.Instance;
        }


        [Fact]
        public async Task ChangeLeadStatus_AcceptSuccess()
        {
            var handler = new ChangeLeadStatusCommandHandler(_fixtureSingleton.DbFixture.LeadRepository, _fixtureSingleton.ServiceFixture.Mapper, _fixtureSingleton.ServiceFixture.Mediator);

            var leadId = (await _fixtureSingleton.DbFixture.LeadRepository
                .GetAllCompleteAsync())
                .FirstOrDefault(ld => ld.Status.Equals(LeadStatus.Invited)).Id;

            var dto = new ChangeLeadStatusCommandDto(leadId, NewStatusLead.Accepted);

            var request = new ChangeLeadStatusCommand(dto);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.IsType<ChangeLeadStatusCommandResponse>(result);
            Assert.True(result.Success);
            Assert.False(result.Errors.Any());

        }

        [Fact]
        public async Task ChangeLeadStatus_InvalidNewStatus()
        {
            var handler = new ChangeLeadStatusCommandHandler(_fixtureSingleton.DbFixture.LeadRepository, _fixtureSingleton.ServiceFixture.Mapper, _fixtureSingleton.ServiceFixture.Mediator);

            var leadId = (await _fixtureSingleton.DbFixture.LeadRepository
                .GetAllCompleteAsync())
                .FirstOrDefault(ld => ld.Status.Equals(LeadStatus.Invited)).Id;

            var dto = new ChangeLeadStatusCommandDto(leadId, 0);

            var request = new ChangeLeadStatusCommand(dto);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.IsType<ChangeLeadStatusCommandResponse>(result);
            Assert.False(result.Success);
            Assert.True(result.Errors.Any());

        }

        [Fact]
        public async Task ChangeLeadStatus_InvalidActualLeadStatus()
        {
            var handler = new ChangeLeadStatusCommandHandler(_fixtureSingleton.DbFixture.LeadRepository, _fixtureSingleton.ServiceFixture.Mapper, _fixtureSingleton.ServiceFixture.Mediator);

            var leadId = (await _fixtureSingleton.DbFixture.LeadRepository
                .GetAllCompleteAsync())
                .FirstOrDefault(ld => !ld.Status.Equals(LeadStatus.Invited)).Id;

            var dto = new ChangeLeadStatusCommandDto(leadId, NewStatusLead.Accepted);

            var request = new ChangeLeadStatusCommand(dto);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.IsType<ChangeLeadStatusCommandResponse>(result);
            Assert.False(result.Success);
            Assert.True(result.Errors.Any());
        }
    }
}

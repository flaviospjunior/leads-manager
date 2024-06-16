using Leads.Domain.Aggregates.Lead;
using Leads.SharedKernel.Mediator.Messages;

namespace Leads.Application.Features.Leads.Queries.GetAllLeads
{
    public class GetAllLeadsQueryHandler : Handler<GetAllLeadsQuery, GetAllLeadsQueryResponse>
    {
        private ILeadRepository _leadRepository;

        public GetAllLeadsQueryHandler(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public override async Task<GetAllLeadsQueryResponse> Handle(GetAllLeadsQuery request, CancellationToken cancellationToken)
        {
            var leads = await _leadRepository.GetAllAsync();

            if (!leads.Any())
                return new GetAllLeadsQueryResponse();

            return new GetAllLeadsQueryResponse(leads.ToList());
        }
    }
}

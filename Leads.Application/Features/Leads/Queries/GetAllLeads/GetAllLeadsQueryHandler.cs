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
            if (leads is null)
                return new GetAllLeadsQueryResponse();


            request.ValidationResult = await Validate(request, cancellationToken);

            if (!request.IsValid())
                return ResponseOnFailValidation("Não foi possível obter Leads", request.ValidationResult);

            return new GetAllLeadsQueryResponse(leads.ToList());
        }
    }
}

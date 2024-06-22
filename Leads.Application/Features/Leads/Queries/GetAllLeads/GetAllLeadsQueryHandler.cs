using AutoMapper;
using Leads.Domain.Aggregates.Lead;
using Leads.SharedKernel.Mediator.Messages;
using MediatR;

namespace Leads.Application.Features.Leads.Queries.GetAllLeads
{
    public class GetAllLeadsQueryHandler : Handler<GetAllLeadsQuery, GetAllLeadsQueryResponse>
    {
        private ILeadRepository _leadRepository;

        public GetAllLeadsQueryHandler(ILeadRepository leadRepository, IMapper mapper, IMediator mediator) : base(mapper, mediator)
        {
            _leadRepository = leadRepository;
        }

        public override async Task<GetAllLeadsQueryResponse> Handle(GetAllLeadsQuery request, CancellationToken cancellationToken)
        {
            var leads = await _leadRepository.GetAllCompleteAsync();

            if (!leads.Any())
                return new GetAllLeadsQueryResponse();

            var leadsViewModel = _mapper.Map<List<GetAllLeadsViewModel>>(leads);

            return new GetAllLeadsQueryResponse(leadsViewModel);
        }
    }
}

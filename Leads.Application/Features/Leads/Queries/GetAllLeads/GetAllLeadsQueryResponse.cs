using Leads.SharedKernel.Mediator.Messages;

namespace Leads.Application.Features.Leads.Queries.GetAllLeads
{
    public class GetAllLeadsQueryResponse : BaseHandlerResponse
    {
        public List<GetAllLeadsViewModel> LeadsViewModel { get; set; }

        public GetAllLeadsQueryResponse()
        {
            
        }

        public GetAllLeadsQueryResponse(bool success, string message) : base(success, message)
        {
            
        }

        public GetAllLeadsQueryResponse(List<GetAllLeadsViewModel> leadsViewModel)
        {
            LeadsViewModel = leadsViewModel; 
        }

    }
}

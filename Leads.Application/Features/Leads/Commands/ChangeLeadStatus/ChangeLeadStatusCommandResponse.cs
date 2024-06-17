using Leads.SharedKernel.Mediator.Messages;

namespace Leads.Application.Features.Leads.Commands.ChangeLeadStatus
{
    public class ChangeLeadStatusCommandResponse : BaseHandlerResponse
    {
        public ChangeLeadStatusViewModel LeadViewModel { get; private set; }

        public ChangeLeadStatusCommandResponse()
        {
            
        }

        public ChangeLeadStatusCommandResponse(bool success, string message) : base(success, message)
        {
            
        }

        public ChangeLeadStatusCommandResponse(ChangeLeadStatusViewModel leadViewModel)
        {
            LeadViewModel = leadViewModel;
        }

    }
}

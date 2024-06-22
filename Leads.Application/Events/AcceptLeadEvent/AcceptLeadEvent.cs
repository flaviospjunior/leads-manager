using MediatR;

namespace Leads.Application.Events.AcceptLeadEvent
{
    public class AcceptLeadEvent : INotification
    {
        public Guid LeadId { get; private set; }

        public AcceptLeadEvent(Guid leadId)
        {
            LeadId = leadId;
        }
    }
}

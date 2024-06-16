namespace Leads.Application.Features.Leads.Commands.ChangeLeadStatus
{
    public class ChangeLeadStatusCommandDto
    {
        public Guid LeadId { get; private set; }
        public NewStatusLead NewStatus { get; private set; }
        public ChangeLeadStatusCommandDto(Guid leadId, NewStatusLead newStatus)
        {
           LeadId = leadId;
           NewStatus = newStatus;
        }
    }
}

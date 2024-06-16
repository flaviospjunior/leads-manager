using Leads.Domain.Enums;

namespace Leads.Domain.Aggregates.Lead
{
    public class Lead
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public LeadStatus Status { get; set; }
        public Lead() { }

        public void AcceptLead()
        {
            if (Status == LeadStatus.Invited)
                return;

            Status = LeadStatus.Accepted;
        }

    }

}

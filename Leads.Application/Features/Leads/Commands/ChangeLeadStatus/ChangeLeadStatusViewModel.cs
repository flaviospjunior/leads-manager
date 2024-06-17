using Leads.Domain.Enums;

namespace Leads.Application.Features.Leads.Commands.ChangeLeadStatus
{
    public class ChangeLeadStatusViewModel
    {
        public ChangeLeadStatusViewModel(LeadStatus status, string description, decimal price, decimal finalPrice, DateTime creationDate, string contactName, string contactEmail, string contactPhoneNumber, string suburb)
        {
            Status = status;
            Description = description;
            Price = price;
            FinalPrice = finalPrice;
            CreationDate = creationDate;
            ContactName = contactName;
            ContactEmail = contactEmail;
            ContactPhoneNumber = contactPhoneNumber;
            Suburb = suburb;
        }

        public LeadStatus Status { get; private set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal FinalPrice { get; private set; }
        public DateTime CreationDate { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string Suburb {get; set; }
    }
}

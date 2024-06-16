using Leads.Domain.Enums;

namespace Leads.Domain.Aggregates.Lead
{
    public class Lead
    {
        public Lead(Guid id, string name, string description, decimal price, DateTime creationDate, string email, string phoneNumber)
        {
            Id = id;
            Name = name;
            Status = LeadStatus.Invited;
            Description = description;
            Price = price;
            CreationDate = creationDate == default ? DateTime.Now : creationDate;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public LeadStatus Status { get;  private set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal FinalPrice { get; private set; }
        public DateTime CreationDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public void ChangeLeadStatus(LeadStatus leadStatus)
        {
            switch (leadStatus)
            {
                case LeadStatus.Accepted:
                    Status = LeadStatus.Accepted;
                    ApplyDiscount();
                    break;
                case LeadStatus.Refused:
                    Status = LeadStatus.Refused;
                    break;
            }

        }

        private void ApplyDiscount()
        {
            if (Price > 500)
            {
                FinalPrice = (10 / 100) * Price;
            }
            else
            {
                FinalPrice = Price;
            } 
        }
    }

}

using Leads.Domain.Entities;
using Leads.Domain.Enums;
using Leads.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leads.Domain.Aggregates.Lead
{
    public class Lead : IAggregateRoot
    {
        public Lead(Guid id, string description, decimal price, DateTime creationDate)
        {
            Id = id;
            Status = LeadStatus.Invited;
            Description = description;
            Price = price;
            CreationDate = creationDate == default ? DateTime.Now : creationDate;
        }

        public Guid Id { get; private set; }
        public LeadStatus Status { get;  private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public decimal FinalPrice { get; private set; }
        public DateTime CreationDate { get; private set; }
        public virtual Suburb Suburb { get; private set; }
        public virtual Contact Contact { get; private set; }

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
            var discount = 10m;

            if (Price > 500m)
            {
                FinalPrice = decimal.Multiply(decimal.Divide(100m - discount, 100), Price);
            }
            else
            {
                FinalPrice = Price;
            } 
        }
    }

}

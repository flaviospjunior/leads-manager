using Leads.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Application.Features.Leads.Queries.GetAllLeads
{
    public class GetAllLeadsViewModel
    {
        public LeadStatus Status { get;  set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal FinalPrice { get;  set; }
        public DateTime CreationDate { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string Suburb { get; set; }
    }
}

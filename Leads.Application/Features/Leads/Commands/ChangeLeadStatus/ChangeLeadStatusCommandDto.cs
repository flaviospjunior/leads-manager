using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Application.Features.Leads.Commands.ChangeLeadStatus
{
    public class ChangeLeadStatusCommandDto
    {
        public Guid LeadId { get; private set; }
        public ChangeLeadStatusCommandDto(Guid leadId)
        {
           LeadId = leadId;
        }
    }
}

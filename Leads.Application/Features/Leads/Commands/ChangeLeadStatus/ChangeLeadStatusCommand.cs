using Leads.SharedKernel.Mediator.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Application.Features.Leads.Commands.ChangeLeadStatus
{
    public class ChangeLeadStatusCommand: Command<ChangeLeadStatusCommandResponse>
    {
        public Guid LeadId { get; set; }

        public ChangeLeadStatusCommand(Guid leadId)
        {
            LeadId = leadId;
        }
    }
}

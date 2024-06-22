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
       public ChangeLeadStatusCommandDto ChangeLeadStatusCommandDto { get; private set; }

        public ChangeLeadStatusCommand(ChangeLeadStatusCommandDto changeLeadStatusCommandDto)
        {
            ChangeLeadStatusCommandDto = changeLeadStatusCommandDto;
        }
    }
}

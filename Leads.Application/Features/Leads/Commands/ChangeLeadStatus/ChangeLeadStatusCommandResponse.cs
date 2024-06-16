using Leads.Domain.Aggregates.Lead;
using Leads.SharedKernel.Mediator.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Application.Features.Leads.Commands.ChangeLeadStatus
{
    public class ChangeLeadStatusCommandResponse : BaseHandlerResponse
    {
        public Lead Lead { get; private set; }

        public ChangeLeadStatusCommandResponse()
        {
            
        }

        public ChangeLeadStatusCommandResponse(bool success, string message) : base(success, message)
        {
            
        }

        public ChangeLeadStatusCommandResponse(Lead lead)
        {
            Lead = lead;
        }


    }
}

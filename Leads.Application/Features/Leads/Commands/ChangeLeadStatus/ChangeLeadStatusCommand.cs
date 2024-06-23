using Leads.SharedKernel.Mediator.Messages;

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

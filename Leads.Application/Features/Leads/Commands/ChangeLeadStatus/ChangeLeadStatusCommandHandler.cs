using FluentValidation.Results;
using Leads.Domain.Aggregates.Lead;
using Leads.Domain.Enums;
using Leads.SharedKernel.Mediator.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Application.Features.Leads.Commands.ChangeLeadStatus
{
    public class ChangeLeadStatusCommandHandler : Handler<ChangeLeadStatusCommand, ChangeLeadStatusCommandResponse>
    {
        private ILeadRepository _leadRepository;

        public ChangeLeadStatusCommandHandler(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public override async Task<ChangeLeadStatusCommandResponse> Handle(ChangeLeadStatusCommand request, CancellationToken cancellationToken)
        {
            var lead = await _leadRepository.GetByIdAsync(request.ChangeLeadStatusCommandDto.LeadId);

            if (lead is null)
                return new ChangeLeadStatusCommandResponse(false, "Lead não encontrada");

            request.ValidationResult = await Validate(request, cancellationToken);

            if(!request.IsValid()) 
                return ResponseOnFailValidation("Não foi possível alterar o status da Lead", request.ValidationResult);

            lead.ChangeLeadStatus((LeadStatus)request.ChangeLeadStatusCommandDto.NewStatus);

            await _leadRepository.UpdateAsync(lead);

            return new ChangeLeadStatusCommandResponse(lead);
        }

        protected async override Task<List<ValidationFailure>> Validate( ChangeLeadStatusCommand request, CancellationToken cancellationToken)
        {
            return (await new ChangeLeadStatusCommandValidation().ValidateAsync(request, cancellationToken)).Errors;
        }
    }
}

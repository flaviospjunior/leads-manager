using AutoMapper;
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

        public ChangeLeadStatusCommandHandler(ILeadRepository leadRepository, IMapper mapper) : base(mapper) 
        {
            _leadRepository = leadRepository;
        }

        public override async Task<ChangeLeadStatusCommandResponse> Handle(ChangeLeadStatusCommand request, CancellationToken cancellationToken)
        {
            var lead = await _leadRepository.GetByIdWithSuburbAndContact(request.ChangeLeadStatusCommandDto.LeadId);

            if (lead is null)
                return new ChangeLeadStatusCommandResponse(false, "Lead não encontrada");

            request.ValidationResult = await Validate(request, cancellationToken);

            if(!request.IsValid()) 
                return ResponseOnFailValidation("Não foi possível alterar o status da Lead", request.ValidationResult);

            lead.ChangeLeadStatus((LeadStatus)request.ChangeLeadStatusCommandDto.NewStatus);

            await _leadRepository.UpdateAsync(lead);

            var leadViewModel = _mapper.Map<ChangeLeadStatusViewModel>(lead);

            return new ChangeLeadStatusCommandResponse(leadViewModel);
        }

        protected async override Task<List<ValidationFailure>> Validate( ChangeLeadStatusCommand request, CancellationToken cancellationToken)
        {
            return (await new ChangeLeadStatusCommandValidation().ValidateAsync(request, cancellationToken)).Errors;
        }
    }
}

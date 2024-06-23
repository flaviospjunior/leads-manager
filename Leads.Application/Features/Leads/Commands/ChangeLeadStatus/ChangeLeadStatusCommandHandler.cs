using AutoMapper;
using FluentValidation.Results;
using Leads.Application.Events.AcceptLeadEvent;
using Leads.Domain.Aggregates.Lead;
using Leads.Domain.Enums;
using Leads.SharedKernel.Mediator.Messages;
using MediatR;

namespace Leads.Application.Features.Leads.Commands.ChangeLeadStatus
{
    public class ChangeLeadStatusCommandHandler : Handler<ChangeLeadStatusCommand, ChangeLeadStatusCommandResponse>
    {
        private ILeadRepository _leadRepository;
        private Lead _lead;

        public ChangeLeadStatusCommandHandler(ILeadRepository leadRepository, IMapper mapper, IMediator mediator) : base(mapper, mediator) 
        {
            _leadRepository = leadRepository;
        }

        public override async Task<ChangeLeadStatusCommandResponse> Handle(ChangeLeadStatusCommand request, CancellationToken cancellationToken)
        {
            _lead = await _leadRepository.GetByIdCompleteAsync(request.ChangeLeadStatusCommandDto.LeadId);

            if (_lead is null)
                return new ChangeLeadStatusCommandResponse(false, "Lead não encontrada");

            request.ValidationResult = await Validate(request, cancellationToken);

            if(!request.IsValid()) 
                return ResponseOnFailValidation("Não foi possível alterar o status da Lead", request.ValidationResult);

            _lead.ChangeLeadStatus((LeadStatus)request.ChangeLeadStatusCommandDto.NewStatus);

            await _leadRepository.UpdateAsync(_lead);

            var leadViewModel = _mapper.Map<ChangeLeadStatusViewModel>(_lead);

            if ((int)request.ChangeLeadStatusCommandDto.NewStatus == (int)LeadStatus.Accepted)
                await _mediator.Publish(new AcceptLeadEvent(_lead.Id));


            return new ChangeLeadStatusCommandResponse(leadViewModel);
        }

        protected async override Task<List<ValidationFailure>> Validate(ChangeLeadStatusCommand request, CancellationToken cancellationToken)
        {
            return (await new ChangeLeadStatusCommandValidation(_lead).ValidateAsync(request, cancellationToken)).Errors;
        }
    }
}

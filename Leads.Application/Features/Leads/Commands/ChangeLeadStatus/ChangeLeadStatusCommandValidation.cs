using FluentValidation;
using Leads.Domain.Aggregates.Lead;
using Leads.Domain.Enums;

namespace Leads.Application.Features.Leads.Commands.ChangeLeadStatus
{
    public class ChangeLeadStatusCommandValidation : AbstractValidator<ChangeLeadStatusCommand>
    {
        public ChangeLeadStatusCommandValidation(Lead lead)
        {
            RuleFor(cl => cl.ChangeLeadStatusCommandDto.NewStatus)
                .NotNull()
                .NotEmpty()
                .WithMessage("Novo Status da Lead deve ser informado")
                .IsInEnum().WithMessage("Valor inválido para o novo status");

            RuleFor(cl => cl.ChangeLeadStatusCommandDto.LeadId)
                .NotNull()
                .NotEmpty()
                .WithMessage("O Id da Lead deve ser informado");

            RuleFor(x => lead).Must(s => s.Status.Equals(LeadStatus.Invited)).WithMessage("Status do Lead atual é incompatível com a alteração");
        }
    }
}

using FluentValidation;

namespace Leads.Application.Features.Leads.Commands.ChangeLeadStatus
{
    public class ChangeLeadStatusCommandValidation : AbstractValidator<ChangeLeadStatusCommand>
    {
        public ChangeLeadStatusCommandValidation()
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
        }
    }
}

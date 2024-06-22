using Leads.Application.Services.EmailService;
using Leads.Domain.Aggregates.Lead;
using MediatR;

namespace Leads.Application.Events.AcceptLeadEvent
{
    public class AcceptLeadEventHandler : INotificationHandler<AcceptLeadEvent>
    {
        private readonly IEmailService _emailService;
        private readonly ILeadRepository _leadRepository;

        public AcceptLeadEventHandler(IEmailService emailService, ILeadRepository leadRepository)
        {
            _emailService = emailService;
            _leadRepository = leadRepository;
        }

        public async Task Handle(AcceptLeadEvent notification, CancellationToken cancellationToken)
        {
            var lead = await _leadRepository.GetByIdAsync(notification.LeadId);
            await _emailService.SendAcceptanceEmail(lead.FinalPrice, lead.Id);
        }
    }
}

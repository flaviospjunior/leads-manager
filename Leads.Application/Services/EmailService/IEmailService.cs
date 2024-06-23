namespace Leads.Application.Services.EmailService
{
    public interface IEmailService
    {
        Task SendAcceptanceEmail(decimal leadFinalPrice, Guid leadId);
    }
}

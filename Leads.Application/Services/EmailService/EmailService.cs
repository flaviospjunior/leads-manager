namespace Leads.Application.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private const string RECIPIENT = "vendas@test.com";
        public async Task SendAcceptanceEmail(decimal finalPrice, Guid leadId)
        {
            var message = $"The Lead with Id {leadId} was accepted and has the final price of ${finalPrice} -- TO {RECIPIENT}";
            Console.Write(message);
            return;
        }
    }
}

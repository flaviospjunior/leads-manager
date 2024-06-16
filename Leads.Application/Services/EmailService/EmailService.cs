namespace Leads.Application.Services.EmailService
{
    public class EmailService : IEmailService
    {
        public async Task SendAcceptanceEmail()
        {
            Console.WriteLine("Email sended!");
            return;
        }
    }
}

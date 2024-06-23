using Leads.Application.Services.EmailService;
using Moq;

namespace Leads.Tests.Services
{
    public class MockIEmailService
    {
        public static Mock<IEmailService> GetMock()
        {
            var mock = new Mock<IEmailService>();

            return mock;
        }
    }
}

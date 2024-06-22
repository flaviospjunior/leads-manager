using Leads.Application.Events.AcceptLeadEvent;
using MediatR;
using Moq;

namespace Leads.Tests.Services
{
    public class MockIMediator
    {
        public static Mock<IMediator> GetMock()
        {
            var mock = new Mock<IMediator>();

            mock.Setup(md => md.Publish(It.IsAny<AcceptLeadEvent>, CancellationToken.None)).Returns(Task.CompletedTask);

            return mock;
        }

    }
}

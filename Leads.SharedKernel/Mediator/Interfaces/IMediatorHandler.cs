using Leads.SharedKernel.Mediator.Messages;

namespace Leads.SharedKernel.Mediator.Interfaces
{
    public interface IMediatorHandler
    {
        Task<TResponse> SendCommand<TResponse>(BaseMessage<TResponse> command) where TResponse : BaseHandlerResponse;

        Task<TResponse> SendQuery<TResponse>(BaseMessage<TResponse> query) where TResponse : BaseHandlerResponse;
    }
}

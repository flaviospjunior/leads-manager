using Leads.SharedKernel.Mediator.Interfaces;
using Leads.SharedKernel.Mediator.Messages;
using MediatR;

namespace Leads.SharedKernel.Mediator.Implementations
{
    public class MediatorHandler: IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResponse> SendCommand<TResponse>(BaseMessage<TResponse> command) where TResponse : BaseHandlerResponse
        {
           return await _mediator.Send(command);
        }

        public async Task<TResponse> SendQuery<TResponse>(BaseMessage<TResponse> query) where TResponse : BaseHandlerResponse
        {
            return await _mediator.Send(query);
        }
    }

}

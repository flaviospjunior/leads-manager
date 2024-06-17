using AutoMapper;

namespace Leads.SharedKernel.Mediator.Messages
{
    public abstract class Handler<TCommand, T> : BaseHandler<TCommand, T>
        where T:BaseHandlerResponse
        where TCommand: BaseMessage<T>
    {

        public Handler(IMapper mapper) : base(mapper)
        {
            
        }

    }
}

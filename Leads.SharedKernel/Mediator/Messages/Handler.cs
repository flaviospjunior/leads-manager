using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.SharedKernel.Mediator.Messages
{
    public abstract class Handler<TCommand, T> : BaseHandler<TCommand, T>
        where T:BaseHandlerResponse
        where TCommand: BaseMessage<T>
    {

    }
}

using Leads.SharedKernel.Mediator.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.SharedKernel.Mediator.Interfaces
{
    public interface IMediatorHandler
    {
        Task<TResponse> SendCommand<TResponse>(BaseMessage<TResponse> command) where TResponse : BaseHandlerResponse;

        Task<TResponse> SendQuery<TResponse>(BaseMessage<TResponse> query) where TResponse : BaseHandlerResponse;

    }
}

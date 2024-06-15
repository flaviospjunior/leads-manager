using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Leads.SharedKernel.Mediator.Messages
{
    public abstract class BaseMessage<TResponse> : IRequest<TResponse>
    {
        public BaseMessage()
        {
            
        }

        [JsonIgnore]
        public List<ValidationFailure> ValidationResult { get; set; }

        public virtual bool IsValid()
        {
            return !ValidationResult.Any();
        }

    }
}

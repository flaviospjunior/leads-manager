using AutoMapper;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.SharedKernel.Mediator.Messages
{
    public abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TResponse : BaseHandlerResponse
        where TRequest : BaseMessage<TResponse>
    {
        protected IMapper _mapper;
        public BaseHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        protected virtual Task<List<ValidationFailure>> Validate(TRequest request, CancellationToken cancellationToken)
        {
            return default;
        }

        protected virtual TResponse ResponseOnFailValidation(string message, List<ValidationFailure> validationFailures)
        {
            var response = Activator.CreateInstance<TResponse>();
            response.AddErrors(validationFailures.Select(vf => vf.ErrorMessage).ToList(), message);

            return response;
        }

    }
}

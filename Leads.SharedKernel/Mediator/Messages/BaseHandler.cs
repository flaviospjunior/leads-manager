using AutoMapper;
using FluentValidation.Results;
using Leads.SharedKernel.Mediator.Interfaces;
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
        protected IMediator _mediator;
        public BaseHandler(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
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

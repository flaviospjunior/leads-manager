using Leads.Domain.Aggregates.Lead;
using Leads.SharedKernel.Mediator.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Application.Features.Leads.Queries.GetAllLeads
{
    public class GetAllLeadsQueryResponse : BaseHandlerResponse
    {
        public List<Lead> Leads { get; set; }

        public GetAllLeadsQueryResponse()
        {
            
        }

        public GetAllLeadsQueryResponse(bool success, string message) : base(success, message)
        {
            
        }

        public GetAllLeadsQueryResponse(List<Lead> leads)
        {
            Leads = leads; 
        }

    }
}

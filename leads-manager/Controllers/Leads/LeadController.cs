﻿using Leads.Application.Features.Leads.Commands.ChangeLeadStatus;
using Leads.Application.Features.Leads.Queries.GetAllLeads;
using Leads.SharedKernel.Mediator.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace leads_manager.Controllers.Leads
{
    public class LeadController : MainController
    {
        private readonly IMediatorHandler _mediator;

        public LeadController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }


        [SwaggerOperation(Summary = "Buscar todos os leads", Description ="Retorna todos os leads atualmente inseridos na base de dados")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetAllLeadsQuery))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(GetAllLeadsQuery))]
        [HttpGet]
        public async Task<ActionResult<GetAllLeadsQueryResponse>> Get()
        {
            var response = await _mediator.SendQuery(new GetAllLeadsQuery());
            return CustomResponse(response);
        }


        [SwaggerOperation(Summary ="Teste" )]
        [HttpPatch]
        public async Task<ActionResult<ChangeLeadStatusCommandResponse>> Patch([FromBody]ChangeLeadStatusCommandDto changeLeadStatusCommandDto)
        {
            var response = await _mediator.SendCommand(new ChangeLeadStatusCommand(changeLeadStatusCommandDto));
            return CustomResponse(response);
        }
    }
}

using HelpMeApp.Application.Handlers.Request.Commands;
using HelpMeApp.Application.Handlers.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMeApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        readonly IMediator _mediator;
        public RequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetRequests(GetAllRequestQuery query)
        {
            var dtos = await _mediator.Send(query);
            return Ok(dtos);
        }

        [HttpGet( "GetRequestById")]
        public async Task<ActionResult> GetRequestById(GetRequestByIdQuery query)
        {
            var dto = await _mediator.Send(query);
            return Ok(dto);
        }

        [HttpPost( "CreateRequest")]
        public async Task<ActionResult> CreateRequest(AddRequestCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut( "UpdateRequest")]
        public async Task<ActionResult> UpdateRequest(UpdateRequestCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete( "DeleteRequest")]
        public async Task<ActionResult> DeleteRequest(DeleteRequestCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}

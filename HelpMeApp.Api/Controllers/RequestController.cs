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
            try
            {
                var dtos = await _mediator.Send(query);
                return Ok(dtos);
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        [HttpGet( "GetRequestById/id")]
        public async Task<ActionResult> GetRequestById([FromRoute] Guid id)
        {
            try
            {
                var dto = await _mediator.Send(new GetRequestByIdQuery { Id = id });
                return Ok(dto);
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        [HttpPost( "CreateRequest")]
        public async Task<ActionResult> CreateRequest(AddRequestCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok();
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        [HttpPut( "UpdateRequest")]
        public async Task<ActionResult> UpdateRequest(UpdateRequestCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok();
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        [HttpDelete( "DeleteRequest")]
        public async Task<ActionResult> DeleteRequest(DeleteRequestCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok();
            }
            catch(Exception ex)
            {

            }
            return null;
        }
    }
}

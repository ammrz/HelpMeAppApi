using HelpMeApp.Application.Handlers.Request.Commands;
using HelpMeApp.Application.Handlers.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        protected readonly ILogger<RequestController> _logger;
        public RequestController(IMediator mediator, ILogger<RequestController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetRequests()
        {
            try
            {
                var dtos = await _mediator.Send(new GetAllRequestQuery());
                return Ok(dtos);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
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
                _logger.LogError(ex.Message);
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
                _logger.LogError(ex.Message);
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
                _logger.LogError(ex.Message);
            }
            return null;
        }

        [HttpDelete( "DeleteRequest/id")]
        public async Task<ActionResult> DeleteRequest([FromRoute] Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteRequestCommand { Id = id});
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }
    }
}

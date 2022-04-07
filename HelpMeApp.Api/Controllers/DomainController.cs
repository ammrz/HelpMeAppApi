using HelpMeApp.Application.Dtos;
using HelpMeApp.Application.Handlers.Domain.Commands;
using HelpMeApp.Application.Handlers.Domain.Queries;
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
    public class DomainController : ControllerBase
    {
        readonly IMediator _mediator;
        protected readonly ILogger<DomainController> _logger;
        public DomainController(IMediator mediator, ILogger<DomainController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetDomains()
        {
            try
            {
                var dtos = await _mediator.Send(new GetAllDomainQuery());
                return dtos.Any() ? Ok(dtos) : NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Problem();
        }

        [HttpGet("GetDomainById/{id}")]
        public async Task<ActionResult> GetDomainById([FromRoute] Guid id)
        {
            try
            {
                var dto = await _mediator.Send(new GetDomainByIdQuery { Id = id });
                return dto != null ? Ok(dto) : NotFound();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Problem();
        }

        [HttpPost("CreateDomain")]
        public async Task<ActionResult> CreateDomain(AddDomainCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);
                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Problem();
        }

        [HttpPut("UpdateDomain")]
        public async Task<ActionResult> UpdateDomain(UpdateDomainCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Problem();
        }

        [HttpDelete("DeleteDomain/{id}")]
        public async Task<ActionResult> DeleteDomain([FromRoute] Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteDomainCommand { Id = id});
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Problem();
        }
    }
}

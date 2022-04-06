using HelpMeApp.Application.Dtos;
using HelpMeApp.Application.Handlers.Domain.Commands;
using HelpMeApp.Application.Handlers.Domain.Queries;
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
    public class DomainController : ControllerBase
    {
        readonly IMediator _mediator;
        public DomainController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetDomains()
        {
            try
            {
                var dtos = await _mediator.Send(new GetAllDomainQuery());
                return Ok(dtos);
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        [HttpGet("GetDomainById/{id}")]
        public async Task<ActionResult> GetDomainById([FromRoute] Guid id)
        {
            try
            {
                var dto = await _mediator.Send(new GetDomainByIdQuery { Id = id });
                return Ok(dto);
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        [HttpPost("CreateDomain")]
        public async Task<ActionResult> CreateDomain(AddDomainCommand command)
        {
            try
            {
                await _mediator.Send(command);

            }
            catch (Exception ex)
            {

            }
            return Ok();
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

            }
            return null;
        }

        [HttpDelete("DeleteDomain")]
        public async Task<ActionResult> DeleteDomain(DeleteDomainCommand command)
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

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
        public async Task<List<DomainDto>> GetDomains()
        {
            try
            {
                var dtos = await _mediator.Send(new GetAllDomainQuery());
                return dtos;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        [HttpGet("GetDomainById")]
        public async Task<ActionResult> GetDomainById(GetDomainByIdQuery query)
        {
            var dto = await _mediator.Send(query);
            return Ok(dto);
        }

        [HttpPost("CreateDomain")]
        public async Task<ActionResult> CreateDomain(AddDomainCommand command)
        {
            try
            {
                await _mediator.Send(command);
               
            }
            catch(Exception ex)
            {

            }
            return Ok();
        }

        [HttpPut("UpdateDomain")]
        public async Task<ActionResult> UpdateDomain(UpdateDomainCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("DeleteDomain")]
        public async Task<ActionResult> DeleteDomain(DeleteDomainCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}

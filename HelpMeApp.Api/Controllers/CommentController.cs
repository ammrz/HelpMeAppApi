using HelpMeApp.Application.Handlers.Comment.Commands;
using HelpMeApp.Application.Handlers.Comment.Queries;
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
    public class CommentController : ControllerBase
    {
        readonly IMediator _mediator;
        protected readonly ILogger<CommentController> _logger;
        public CommentController(IMediator mediator, ILogger<CommentController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetComments()
        {
            try
            {
                var dtos = await _mediator.Send(new GetAllCommentQuery());
                return dtos.Any() ? Ok(dtos) : NotFound();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Problem();
        }

        [HttpGet("GetCommentById/{id}")]
        public async Task<ActionResult> GetCommentById([FromRoute] Guid id)
        {
            try
            {
                var dto = await _mediator.Send(new GetCommentByIdQuery { Id = id });
                return dto != null ? Ok(dto) : NotFound();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Problem();
        }

        [HttpPost("CreateComment")]
        public async Task<ActionResult> CreateComment(AddCommentCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);
                return Ok(id);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Problem();
        }

        [HttpPut("UpdateComment")]
        public async Task<ActionResult> UpdateComment(UpdateCommentCommand command)
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
            return Problem();
        }

        [HttpDelete("DeleteComment/{id}")]
        public async Task<ActionResult> DeleteComment([FromRoute] Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteCommentCommand { Id =id});
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

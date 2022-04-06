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
                return Ok(dtos);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        [HttpGet("GetCommentById/id")]
        public async Task<ActionResult> GetCommentById([FromRoute] Guid id)
        {
            try
            {
                var dto = await _mediator.Send(new GetCommentByIdQuery { Id = id });
                return Ok(dto);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        [HttpPost("CreateComment")]
        public async Task<ActionResult> CreateComment(AddCommentCommand command)
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
            return null;
        }

        [HttpDelete("DeleteComment")]
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
            return null;
        }
    }
}

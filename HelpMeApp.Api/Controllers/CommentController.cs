using HelpMeApp.Application.Handlers.Comment.Commands;
using HelpMeApp.Application.Handlers.Comment.Queries;
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
    public class CommentController : ControllerBase
    {
        readonly IMediator _mediator;
        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetComments(GetAllCommentQuery query)
        {
            var dtos = await _mediator.Send(query);
            return Ok(dtos);
        }

        [HttpGet("GetCommentById")]
        public async Task<ActionResult> GetCommentById(GetCommentByIdQuery query)
        {
            var dto = await _mediator.Send(query);
            return Ok(dto);
        }

        [HttpPost("CreateComment")]
        public async Task<ActionResult> CreateComment(AddCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("UpdateComment")]
        public async Task<ActionResult> UpdateComment(UpdateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("DeleteComment")]
        public async Task<ActionResult> DeleteComment(DeleteCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}

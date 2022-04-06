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

            }
            return null;
        }

        [HttpDelete("DeleteComment")]
        public async Task<ActionResult> DeleteComment(DeleteCommentCommand command)
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

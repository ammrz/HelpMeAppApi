using FluentValidation;
using HelpMeApp.Application.Handlers.Comment.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Application.Handlers.Comment.Validators
{
    public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentCommandValidator()
        {
            RuleFor(x => x.Body).NotEmpty().MaximumLength(200);
        }
    }
}

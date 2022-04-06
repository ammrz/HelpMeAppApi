using FluentValidation;
using HelpMeApp.Application.Handlers.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Application.Handlers.Request.Validators
{
    public class AddRequestCommandValidator : AbstractValidator<AddRequestCommand>
    {
        public AddRequestCommandValidator()
        {
            RuleFor(x => x.Subject).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Body).NotEmpty().MaximumLength(100);
        }
    }
}

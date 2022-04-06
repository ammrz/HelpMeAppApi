using FluentValidation;
using HelpMeApp.Application.Handlers.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Application.Handlers.Domain.Validators
{
    public class AddDomainCommandValidator : AbstractValidator<AddDomainCommand>
    {
        public AddDomainCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Desciption).NotEmpty().MaximumLength(100);
        }
    }
}

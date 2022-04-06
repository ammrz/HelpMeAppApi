using FluentValidation;
using HelpMeApp.Application.Handlers.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Application.Handlers.Domain.Validators
{
    public class UpdateDomainCommandValidator : AbstractValidator<UpdateDomainCommand>
    {
        public UpdateDomainCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
        }
    }
}

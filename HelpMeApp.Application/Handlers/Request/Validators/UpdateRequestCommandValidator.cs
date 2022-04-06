using FluentValidation;
using HelpMeApp.Application.Handlers.Request.Commands;

namespace HelpMeApp.Application.Handlers.Request.Validators
{
    public class UpdateRequestCommandValidator : AbstractValidator<UpdateRequestCommand>
    {
        public UpdateRequestCommandValidator()
        {
            RuleFor(x => x.Subject).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Body).NotEmpty().MaximumLength(100);
        }
    }
}

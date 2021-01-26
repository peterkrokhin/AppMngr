using FluentValidation;

namespace AppMngr.Application
{
    public class CreateAppTypeCommandValidator : AbstractValidator<CreateAppTypeCommand>
    {
        public CreateAppTypeCommandValidator()
        {
            RuleFor(p => p.Name).NotNull().MinimumLength(3);
        }
    }
}
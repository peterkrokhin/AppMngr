using FluentValidation;

namespace AppMngr.Application
{
    public class CreateTimeFieldCommandValidator : AbstractValidator<CreateTimeFieldCommand>
    {
        public CreateTimeFieldCommandValidator()
        {
            RuleFor(p => p.Value).NotNull();
            RuleFor(p => p.AppTypeId).GreaterThan(0);
        }
    }
}
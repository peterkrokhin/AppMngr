using FluentValidation;

namespace AppMngr.Application
{
    public class CreateDateFieldCommandValidator : AbstractValidator<CreateDateFieldCommand>
    {
        public CreateDateFieldCommandValidator()
        {
            RuleFor(p => p.Value).NotNull();
            RuleFor(p => p.AppTypeId).GreaterThan(0);
        }
    }
}
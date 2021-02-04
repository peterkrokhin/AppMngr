using FluentValidation;

namespace AppMngr.Application
{
    public class CreateNumFieldCommandValidator : AbstractValidator<CreateNumFieldCommand>
    {
        public CreateNumFieldCommandValidator()
        {
            RuleFor(p => p.Value).NotNull();
            RuleFor(p => p.AppTypeId).GreaterThan(0);
        }
    }
}
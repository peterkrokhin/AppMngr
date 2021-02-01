using FluentValidation;

namespace AppMngr.Application
{
    public class CreateStringFieldCommandValidator : AbstractValidator<CreateStringFieldCommand>
    {
        public CreateStringFieldCommandValidator()
        {
            RuleFor(p => p.Value).NotNull().MinimumLength(2);
            RuleFor(p => p.AppTypeId).GreaterThan(0);
        }
    }
}
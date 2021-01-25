using FluentValidation;

namespace AppMngr.Application
{
    public class CreateAppCommandValidator : AbstractValidator<CreateAppCommand>
    {
        public CreateAppCommandValidator()
        {
            RuleFor(p => p.Name).NotNull().MinimumLength(2);
            RuleFor(p => p.StatusId).GreaterThan(0);
            RuleFor(p => p.AppTypeId).GreaterThan(0);
        }
    }
}
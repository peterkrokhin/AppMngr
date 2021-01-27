using FluentValidation;

namespace AppMngr.Application
{
    public class CreateStatusCommandValidator : AbstractValidator<CreateStatusCommand>
    {
        public CreateStatusCommandValidator()
        {
            RuleFor(p => p.Value).NotNull().MinimumLength(2);
            RuleFor(p => p.AppTypeId).GreaterThan(0);
        }
    }
}
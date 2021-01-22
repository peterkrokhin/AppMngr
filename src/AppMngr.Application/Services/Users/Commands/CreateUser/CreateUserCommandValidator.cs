using FluentValidation;

namespace AppMngr.Application
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Name).NotNull().MinimumLength(3);
            RuleFor(p => p.Pwd).NotNull().MinimumLength(6);
            RuleFor(p => p.RoleId).GreaterThan(0);
        }
    }
}
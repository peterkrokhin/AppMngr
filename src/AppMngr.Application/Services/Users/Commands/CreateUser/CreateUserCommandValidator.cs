using FluentValidation;

namespace AppMngr.Application
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Name).NotNull().Length(3, 100);
            RuleFor(p => p.Pwd).NotNull().Length(6, 100);
            RuleFor(p => p.RoleId).GreaterThan(0);
        }
    }
}
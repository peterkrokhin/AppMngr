using FluentValidation;

namespace AppMngr.Application
{
    public class GetUserByNameAndPasswordQueryValidator : 
        AbstractValidator<GetUserByNameAndPasswordQuery>
    {
        public GetUserByNameAndPasswordQueryValidator()
        {
            RuleFor(p => p.Name).NotNull().Length(3, 100);
            RuleFor(p => p.Password).NotNull().Length(3, 100);
        }
    }
}
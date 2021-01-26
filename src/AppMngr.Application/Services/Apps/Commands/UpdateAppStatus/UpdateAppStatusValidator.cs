using FluentValidation;

namespace AppMngr.Application
{
    public class UpdateAppStatusValidator : AbstractValidator<UpdateAppStatusCommand>
    {
        public UpdateAppStatusValidator()
        {
            RuleFor(p => p.StatusId).GreaterThan(0);
        }
    }
}
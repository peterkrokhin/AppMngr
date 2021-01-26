using FluentValidation;

namespace AppMngr.Application
{
    public class UpdateAppStatusValidator : AbstractValidator<UpdateAppStatusCommand>
    {
        public UpdateAppStatusValidator()
        {
            RuleFor(p => p.AppId).GreaterThan(0);
            RuleFor(p => p.StatusId).GreaterThan(0);
        }
    }
}
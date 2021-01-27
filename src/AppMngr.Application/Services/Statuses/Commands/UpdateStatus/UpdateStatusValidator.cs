using FluentValidation;

namespace AppMngr.Application
{
    public class UpdateStatusValidator : AbstractValidator<UpdateStatusCommand>
    {
        public UpdateStatusValidator()
        {
        }
    }
}
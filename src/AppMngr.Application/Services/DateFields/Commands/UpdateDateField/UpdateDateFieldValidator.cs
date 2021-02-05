using FluentValidation;

namespace AppMngr.Application
{
    public class UpdateDateFieldValidator : AbstractValidator<UpdateDateFieldCommand>
    {
        public UpdateDateFieldValidator()
        {
        }
    }
}
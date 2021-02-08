using FluentValidation;

namespace AppMngr.Application
{
    public class UpdateTimeFieldValidator : AbstractValidator<UpdateTimeFieldCommand>
    {
        public UpdateTimeFieldValidator()
        {
        }
    }
}
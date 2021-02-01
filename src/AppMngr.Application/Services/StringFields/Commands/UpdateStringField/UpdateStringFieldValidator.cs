using FluentValidation;

namespace AppMngr.Application
{
    public class UpdateStringFieldValidator : AbstractValidator<UpdateStringFieldCommand>
    {
        public UpdateStringFieldValidator()
        {
        }
    }
}
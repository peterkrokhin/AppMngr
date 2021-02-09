using FluentValidation;

namespace AppMngr.Application
{
    public class CreateFileMetaDataCommandValidator : AbstractValidator<CreateFileMetaDataCommand>
    {
        public CreateFileMetaDataCommandValidator()
        {
            RuleFor(p => p.AppTypeId).GreaterThan(0);
        }
    }
}
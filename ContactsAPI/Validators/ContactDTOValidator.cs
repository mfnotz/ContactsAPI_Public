using Core.DTOs;
using FluentValidation;

namespace API.Validators
{
    public class ContactDTOValidator : AbstractValidator<ContactDTO>
    {
        public ContactDTOValidator() 
        {
            RuleFor(prop => prop.Email)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .EmailAddress().WithMessage("{PropertyName} is not a valid e-mail address");
        }

    }

    public class CreateContactDTOValidator : AbstractValidator<CreateContactDTO>
    {
        public CreateContactDTOValidator()
        {
            RuleFor(prop => prop.Email)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .EmailAddress().WithMessage("{PropertyName} is not a valid e-mail address");
        }

    }

    public class UpdateContactDTOValidator : AbstractValidator<UpdateContactDTO>
    {
        public UpdateContactDTOValidator()
        {
            RuleFor(prop => prop.Email)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .EmailAddress().WithMessage("{PropertyName} is not a valid e-mail address");
        }

    }
}

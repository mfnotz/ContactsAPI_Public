using Core.DTOs;
using FluentValidation;

namespace API.Validators
{
    public class LoginInfoDTOValidator : AbstractValidator<LoginInfoDTO>
    {
        public LoginInfoDTOValidator()
        {
            RuleFor(prop => prop.Email)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(prop => prop.Password)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");
           
        }
    }
}

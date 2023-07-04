using Core.DTOs;
using FluentValidation;

namespace API.Validators
{
    public class UserSkillDTOValidator : AbstractValidator<UserSkillDTO>
    {
        public UserSkillDTOValidator() 
        {
            RuleFor(prop => prop.SkillId)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(prop => prop.ContactId)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(prop => prop.Level)
                .IsInEnum().WithMessage("{PropertyName} value is not valid");
        }
    }
}

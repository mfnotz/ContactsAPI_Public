using Core.DTOs;
using FluentValidation;

namespace API.Validators
{
    public class SkillDTOValidator : AbstractValidator<SkillDTO>
    {
        public SkillDTOValidator()
        {
            RuleFor(prop => prop.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }

    public class CreateSkillDTOValidator : AbstractValidator<CreateSkillDTO>
    {
        public CreateSkillDTOValidator()
        {
            RuleFor(prop => prop.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }

    public class UpdateSkillDTOValidator : AbstractValidator<UpdateSkillDTO>
    {
        public UpdateSkillDTOValidator()
        {
            RuleFor(prop => prop.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }
}

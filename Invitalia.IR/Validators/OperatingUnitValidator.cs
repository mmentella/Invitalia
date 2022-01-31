using FluentValidation;
using Invitalia.Infrastructures.Model;
using System;
using System.Linq.Expressions;

namespace Invitalia.Infrastructures.Validators
{
    public class OperatingUnitValidator
        : AbstractValidator<OperatingUnit>
    {
        public OperatingUnitValidator()
        {
            Expression<Func<Core.Model.OperatingUnit, object>> skip = u => u.Name;
            Include(new Core.Validators.OperatingUnitValidator(skip));

            RuleFor(u => u.Name)
                .MaximumLength(50)
                    .WithMessage($"{nameof(OperatingUnit.Name)} length should be less or equal to 50");
            RuleFor(u => u.Skills)
                .NotEmpty()
                    .WithMessage($"{nameof(OperatingUnit.Skills)} is mandatory");
        }
    }
}

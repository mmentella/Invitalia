using FluentValidation;
using Invitalia.Core.Model;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Invitalia.Core.Validators
{
    public class OperatingUnitValidator
        : AbstractValidator<OperatingUnit>
    {
        public OperatingUnitValidator()
            : this(Array.Empty<Expression<Func<OperatingUnit, object>>>()) { }

        public OperatingUnitValidator(params Expression<Func<OperatingUnit, object>>[] skipProperties)
        {
            Expression<Func<OperatingUnit, object>> skipExpr = u => u.Name;

            if (!skipProperties.Any(p => ((MemberExpression)p.Body).Member.Name == ((MemberExpression)skipExpr.Body).Member.Name))
            {
                RuleFor(u => u.Name)
                    .NotEmpty()
                        .WithMessage($"{nameof(OperatingUnit.Name)} is mandatory");
            }

            skipExpr = u => u.Type;

            if (!skipProperties.Any(p => ((MemberExpression)p.Body).Member.Name == ((MemberExpression)skipExpr.Body).Member.Name))
            {
                RuleFor(u => u.Type)
                        .NotNull()
                            .WithMessage($"{nameof(OperatingUnit.Type)} is mandatory");
            }
        }
    }
}

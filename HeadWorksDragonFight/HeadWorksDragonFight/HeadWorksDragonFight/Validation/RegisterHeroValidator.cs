using FluentValidation;
using FluentValidation.Validators;
using HeadWorksDragonFight.Models;
using System;

namespace HeadWorksDragonFight.Validation
{
    public class RegisterHeroValidator : AbstractValidator<RegisterHero>
    {
        public RegisterHeroValidator()
        {
            RuleFor(user => user.Login).NotNull().MinimumLength(4).MaximumLength(20).Matches(@"^\S\w*").Matches(@"\w*\S$").Matches(@"[a-z,0-9]");
        }

    }
}


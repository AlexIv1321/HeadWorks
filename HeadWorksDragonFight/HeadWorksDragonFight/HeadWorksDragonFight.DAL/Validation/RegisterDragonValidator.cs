using FluentValidation;
using HeadWorksDragonFight.Dal.Models;

namespace HeadWorksDragonFight.DAL.Validation
{
    public class RegisterDragonValidator : AbstractValidator<DragonDal>
    {
        public RegisterDragonValidator()
        {
            RuleFor(dragon => dragon.Name).NotNull().MinimumLength(4).MaximumLength(20).Matches(@"^\S\w*").Matches(@"\w*\S$").Matches(@"[a-z,0-9]");
        }

    }
}


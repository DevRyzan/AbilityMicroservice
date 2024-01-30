using Domain.Enums;
using FluentValidation;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Commands.Create;

public class CreateAbilityLevelValidator : AbstractValidator<CreateAbilityLevelCommandRequest>
{
    public CreateAbilityLevelValidator()
    {
        RuleFor(x => x.CreateAbilityLevelDto.LevelNumber).Must(BeAValidLevelNumberValue);
    }

    private bool BeAValidLevelNumberValue(LevelNumber levelNumber)
    {
        return Enum.IsDefined(typeof(LevelNumber), levelNumber);
    }
}

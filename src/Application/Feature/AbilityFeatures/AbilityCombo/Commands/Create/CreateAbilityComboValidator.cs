using Domain.Enums;
using FluentValidation;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Commands.Create;

public class CreateAbilityComboValidator : AbstractValidator<CreateAbilityComboCommandRequest>
{
    public CreateAbilityComboValidator()
    {
        RuleFor(x => x.CreateAbilityComboDto.ComboNumber).Must(BeAValidComboNumberValue);
    }
    private bool BeAValidComboNumberValue(ComboNumber comboNumber)
    {
        return Enum.IsDefined(typeof(ComboNumber), comboNumber);
    }
}

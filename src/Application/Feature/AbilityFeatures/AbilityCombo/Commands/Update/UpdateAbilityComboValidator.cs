using Domain.Enums;
using FluentValidation;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Commands.Update;

public class UpdateAbilityComboValidator : AbstractValidator<UpdateAbilityComboCommandRequest>
{
    public UpdateAbilityComboValidator()
    {
        RuleFor(x => x.UpdateAbilityComboDto.ComboNumber).Must(BeAValidComboNumberValue);
    }
    private bool BeAValidComboNumberValue(ComboNumber comboNumber)
    {
        return Enum.IsDefined(typeof(ComboNumber), comboNumber);
    }
}

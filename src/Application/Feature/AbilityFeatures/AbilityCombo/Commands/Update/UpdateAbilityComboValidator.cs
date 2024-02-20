using Domain.Enums;
using FluentValidation;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Commands.Update;

public class UpdateAbilityComboValidator : AbstractValidator<UpdateAbilityComboCommandRequest>
{
    public UpdateAbilityComboValidator()
    {
        RuleFor(x => x.UpdateAbilityComboDto.Name)
                .NotNull().WithMessage("Name, should not be null.")
                .MinimumLength(2);
    }
    private bool BeAValidComboNumberValue(ComboNumber comboNumber)
    {
        return Enum.IsDefined(typeof(ComboNumber), comboNumber);
    }
}

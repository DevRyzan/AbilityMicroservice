using Domain.Enums;
using FluentValidation;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Commands.Create;

public class CreateAbilityComboValidator : AbstractValidator<CreateAbilityComboCommandRequest>
{
    public CreateAbilityComboValidator()
    {
        RuleFor(x => x.CreateAbilityComboDto.Name)
                .NotNull().WithMessage("Name, should not be null.")
                .MinimumLength(2);

        RuleFor(x => x.CreateAbilityComboDto.Description)
                .NotNull().WithMessage("Description, should not be null.")
                .MinimumLength(2);
    }
    private bool BeAValidComboNumberValue(ComboNumber comboNumber)
    {
        return Enum.IsDefined(typeof(ComboNumber), comboNumber);
    }
}

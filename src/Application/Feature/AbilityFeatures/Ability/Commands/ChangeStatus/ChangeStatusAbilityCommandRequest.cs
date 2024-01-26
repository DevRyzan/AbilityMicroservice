using MediatR;

namespace Application.Feature.AbilityFeatures.Ability.Commands.ChangeStatus;

public class ChangeStatusAbilityCommandRequest : IRequest<ChangeStatusAbilityCommandResponse>
{
    public Guid Id { get; set; }
}

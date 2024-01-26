using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Commands.Remove;

public class RemoveAbilityCategoryCommandRequest : IRequest<RemovedAbilityCategoryCommandResponse>
{
    public Guid Id { get; set; }
}

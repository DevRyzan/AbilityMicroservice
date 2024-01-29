using Application.Feature.AbilityFeatures.AbilityCategory.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Commands.Remove;

public class RemoveAbilityCategoryCommandRequest : IRequest<RemovedAbilityCategoryCommandResponse>
{
    public AbilityCategoryRemoveDto AbilityCategoryRemoveDto { get; set; }
}

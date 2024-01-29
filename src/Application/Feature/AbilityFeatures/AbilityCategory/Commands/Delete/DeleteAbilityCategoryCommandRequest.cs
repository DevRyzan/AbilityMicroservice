using Application.Feature.AbilityFeatures.AbilityCategory.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Commands.Delete;

public class DeleteAbilityCategoryCommandRequest : IRequest<DeletedAbilityCategoryCommandResponse>
{
    public AbilityCategoryDeleteDto AbilityCategoryDeleteDto { get; set; }
}

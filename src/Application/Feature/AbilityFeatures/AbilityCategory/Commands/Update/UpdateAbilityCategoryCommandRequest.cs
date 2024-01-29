using Application.Feature.AbilityFeatures.AbilityCategory.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Commands.Update;

public class UpdateAbilityCategoryCommandRequest : IRequest<UpdatedAbilityCategoryCommandResponse>
{
    public AbilityCategoryUpdateDto AbilityCategoryUpdateDto { get; set; }
}

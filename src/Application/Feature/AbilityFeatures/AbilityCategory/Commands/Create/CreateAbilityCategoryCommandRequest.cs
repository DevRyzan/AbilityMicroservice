using Amazon.Runtime.Internal;
using Application.Feature.AbilityFeatures.AbilityCategory.Dto;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Commands.Create;

public class CreateAbilityCategoryCommandRequest : IRequest<CreatedAbilityCategoryCommandResponse>
{
    public AbilityCategoryCreateDto AbilityCategoryCreateDto { get; set; }

}

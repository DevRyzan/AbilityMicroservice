using Amazon.Runtime.Internal;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Commands.Create;

public class CreateAbilityCategoryCommandRequest : IRequest<CreatedAbilityCategoryCommandResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }

}

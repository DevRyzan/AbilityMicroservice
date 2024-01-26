using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Commands.Update;

public class UpdateAbilityCategoryCommandRequest : IRequest<UpdatedAbilityCategoryCommandResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

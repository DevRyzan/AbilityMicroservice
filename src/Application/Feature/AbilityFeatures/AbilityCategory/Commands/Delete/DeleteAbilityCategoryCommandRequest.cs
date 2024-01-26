using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Commands.Delete;

public class DeleteAbilityCategoryCommandRequest : IRequest<DeletedAbilityCategoryCommandResponse>
{
    public Guid Id { get; set; }
}

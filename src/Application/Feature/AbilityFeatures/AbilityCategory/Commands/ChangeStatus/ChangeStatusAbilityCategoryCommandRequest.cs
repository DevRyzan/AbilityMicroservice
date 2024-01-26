using Core.Application.Transaction;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Commands.ChangeStatus;

public class ChangeStatusAbilityCategoryCommandRequest : IRequest<ChangeStatusAbilityCategoryCommandResponse>, ITransactionalRequest
{
    public Guid Id { get; set; }
}

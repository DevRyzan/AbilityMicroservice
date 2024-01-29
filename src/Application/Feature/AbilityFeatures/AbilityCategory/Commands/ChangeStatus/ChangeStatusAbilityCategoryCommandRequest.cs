using Application.Feature.AbilityFeatures.AbilityCategory.Dto;
using Core.Application.Transaction;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Commands.ChangeStatus;

public class ChangeStatusAbilityCategoryCommandRequest : IRequest<ChangeStatusAbilityCategoryCommandResponse>, ITransactionalRequest
{
    public AbilityCategoryChangeStatusDto AbilityCategoryChangeStatusDto { get; set; }
}

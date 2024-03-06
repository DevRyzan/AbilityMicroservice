using Application.Feature.AbilityFeatures.AbilityAffectUnits.Dto;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.ChangeStatus;

public class ChangeStatusAbilityAffectUnitRequest : IRequest<ChangeStatusAbilityAffectUnitResponse>
{
    public ChangeStatusAbilityAffectUnitDto ChangeStatusAbilityAffectUnitDto { get; set; }
}

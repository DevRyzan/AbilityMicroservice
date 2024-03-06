using Application.Feature.AbilityFeatures.AbilityAffectUnits.Rules;
using Application.Service.AbilityServices.AbilityAffectUnitService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Remove;

public class RemoveAbilityAffectUnitHandler : IRequestHandler<RemoveAbilityAffectUnitRequest, RemoveAbilityAffectUnitResponse>
{
    private readonly IAbilityAffectUnitService _abilityAffectUnitService;
    private readonly AbilityAffectUnitBusinessRules _abilityAffectUnitBusinessRules;
    private readonly IMapper _mapper;

    public RemoveAbilityAffectUnitHandler(IAbilityAffectUnitService abilityAffectUnitService, AbilityAffectUnitBusinessRules abilityAffectUnitBusinessRules, IMapper mapper)
    {
        _abilityAffectUnitService = abilityAffectUnitService;
        _abilityAffectUnitBusinessRules = abilityAffectUnitBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveAbilityAffectUnitResponse> Handle(RemoveAbilityAffectUnitRequest request, CancellationToken cancellationToken)
    {
        await _abilityAffectUnitBusinessRules.RemoveCondition(id: request.RemoveAbilityAffectUnitDto.Id);
        await _abilityAffectUnitBusinessRules.IdShouldBeExist(request.RemoveAbilityAffectUnitDto.Id);

        AbilityAffectUnit abilityAffectUnit = await _abilityAffectUnitService.GetById(request.RemoveAbilityAffectUnitDto.Id);

        await _abilityAffectUnitService.Remove(abilityAffectUnit);

        RemoveAbilityAffectUnitResponse mappedResponse = _mapper.Map<RemoveAbilityAffectUnitResponse>(abilityAffectUnit);
        return mappedResponse;
    }
}

using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectDisableTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;



namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Remove;

public class RemoveAbilityEffectDisableTypeHandler : IRequestHandler<RemoveAbilityEffectDisableTypeRequest, RemoveAbilityEffectDisableTypeResponse>
{
    private readonly IAbilityEffectDisableTypeService _abilityEffectDisableTypeService;
    private readonly AbilityEffectDisableTypeBusinessRules _abilityEffectDisableTypeBusinessRules;
    private readonly IMapper _mapper;

    public RemoveAbilityEffectDisableTypeHandler(IAbilityEffectDisableTypeService abilityEffectDisableTypeService, AbilityEffectDisableTypeBusinessRules abilityEffectDisableTypeBusinessRules, IMapper mapper)
    {
        _abilityEffectDisableTypeService = abilityEffectDisableTypeService;
        _abilityEffectDisableTypeBusinessRules = abilityEffectDisableTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveAbilityEffectDisableTypeResponse> Handle(RemoveAbilityEffectDisableTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityEffectDisableTypeBusinessRules.IdShouldBeExist(request.RemoveAbilityEffectDisableTypeDto.Id);
        await _abilityEffectDisableTypeBusinessRules.RemoveCondition(request.RemoveAbilityEffectDisableTypeDto.Id);

        AbilityEffectDisableType abilityEffectDisableType = await _abilityEffectDisableTypeService.GetById(request.RemoveAbilityEffectDisableTypeDto.Id);
        await _abilityEffectDisableTypeService.Remove(abilityEffectDisableType);

        RemoveAbilityEffectDisableTypeResponse mappedResponse = _mapper.Map<RemoveAbilityEffectDisableTypeResponse>(abilityEffectDisableType);
        return mappedResponse;
    }
}

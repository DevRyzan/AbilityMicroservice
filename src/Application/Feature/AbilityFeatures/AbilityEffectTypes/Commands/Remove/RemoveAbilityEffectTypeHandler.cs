using Application.Feature.AbilityFeatures.AbilityEffectTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Remove;

public class RemoveAbilityEffectTypeHandler : IRequestHandler<RemoveAbilityEffectTypeRequest, RemoveAbilityEffectTypeResponse>
{
    private readonly IAbilityEffectTypeService _abilityTypeService;
    private readonly AbilityEffectTypeBusinessRules _abilityEffectTypeBusinessRules;
    private readonly IMapper _mapper;

    public RemoveAbilityEffectTypeHandler(IAbilityEffectTypeService abilityTypeService, AbilityEffectTypeBusinessRules abilityEffectTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityEffectTypeBusinessRules = abilityEffectTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveAbilityEffectTypeResponse> Handle(RemoveAbilityEffectTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityEffectTypeBusinessRules.IdShouldBeExist(request.RemoveAbilityEffectTypeDto.Id);

        await _abilityEffectTypeBusinessRules.RemoveCondition(id: request.RemoveAbilityEffectTypeDto.Id);

        AbilityEffectType abilityEffectType = await _abilityTypeService.GetById(request.RemoveAbilityEffectTypeDto.Id);

        await _abilityTypeService.Remove(abilityEffectType);

        RemoveAbilityEffectTypeResponse mappedResponse = _mapper.Map<RemoveAbilityEffectTypeResponse>(abilityEffectType);

        return mappedResponse;

    }
}

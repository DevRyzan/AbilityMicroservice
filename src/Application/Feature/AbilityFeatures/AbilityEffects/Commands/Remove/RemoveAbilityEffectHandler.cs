using Application.Feature.AbilityFeatures.AbilityEffects.Rules;
using Application.Service.AbilityServices.AbilityEffectService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffects.Commands.Remove;

public class RemoveAbilityEffectHandler : IRequestHandler<RemoveAbilityEffectRequest, RemoveAbilityEffectResponse>
{
    private readonly IAbilityEffectService _abilityEffectService;
    private readonly AbilityEffectBusinessRules _abilityEffectBusinessRules;
    private readonly IMapper _mapper;

    public RemoveAbilityEffectHandler(IAbilityEffectService abilityEffectService, AbilityEffectBusinessRules abilityEffectBusinessRules, IMapper mapper)
    {
        _abilityEffectService = abilityEffectService;
        _abilityEffectBusinessRules = abilityEffectBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveAbilityEffectResponse> Handle(RemoveAbilityEffectRequest request, CancellationToken cancellationToken)
    {
        await _abilityEffectBusinessRules.IdShouldBeExist(request.RemoveAbilityEffectDto.Id);
        await _abilityEffectBusinessRules.RemoveCondition(request.RemoveAbilityEffectDto.Id);

        AbilityEffect abilityEffect = await _abilityEffectService.GetById(request.RemoveAbilityEffectDto.Id);

        await _abilityEffectService.Remove(abilityEffect);

        RemoveAbilityEffectResponse mappedResponse = _mapper.Map<RemoveAbilityEffectResponse>(abilityEffect);

        return mappedResponse;
    }
}

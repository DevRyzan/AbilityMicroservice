using Application.Feature.AbilityFeatures.AbilityEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.Remove;

public class RemoveAbilityEffectStatHandler : IRequestHandler<RemoveAbilityEffectStatRequest, RemoveAbilityEffectStatResponse>
{
    private readonly IAbilityEffectStatService _abilityEffectStatService;
    private readonly AbilityEffectStatBusinessRules _abilityEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public RemoveAbilityEffectStatHandler(IAbilityEffectStatService abilityEffectStatService, AbilityEffectStatBusinessRules abilityEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEffectStatService = abilityEffectStatService;
        _abilityEffectStatBusinessRules = abilityEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveAbilityEffectStatResponse> Handle(RemoveAbilityEffectStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityEffectStatBusinessRules.IdShouldBeExist(request.RemoveAbilityEffectStatDto.Id);
        await _abilityEffectStatBusinessRules.RemoveCondition(request.RemoveAbilityEffectStatDto.Id);

        AbilityEffectStat abilityEffectStat = await _abilityEffectStatService.GetById(request.RemoveAbilityEffectStatDto.Id);

        await _abilityEffectStatService.Remove(abilityEffectStat);

        RemoveAbilityEffectStatResponse mappedResponse = _mapper.Map<RemoveAbilityEffectStatResponse>(abilityEffectStat);
        return mappedResponse;
    }
}

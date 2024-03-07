using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityAllyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.Update;

public class UpdateAbilityAllyEffectStatHandler  : IRequestHandler<UpdateAbilityAllyEffectStatRequest, UpdateAbilityAllyEffectStatResponse>
{
    private readonly IAbilityAllyEffectStatService _abilityAllyEffectStatService;
    private readonly AbilityAllyEffectStatsBusinessRules _abilityAllyEffectStatsBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityAllyEffectStatHandler(IAbilityAllyEffectStatService abilityAllyEffectStatService, AbilityAllyEffectStatsBusinessRules abilityAllyEffectStatsBusinessRules, IMapper mapper)
    {
        _abilityAllyEffectStatService = abilityAllyEffectStatService;
        _abilityAllyEffectStatsBusinessRules = abilityAllyEffectStatsBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityAllyEffectStatResponse> Handle(UpdateAbilityAllyEffectStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityAllyEffectStatsBusinessRules.IdShouldBeExist(request.UpdateAbilityAllyEffectStatDto.Id);

        AbilityAllyEffectStat abilityAllyEffectStat = await _abilityAllyEffectStatService.GetById(request.UpdateAbilityAllyEffectStatDto.Id);

        _mapper.Map(request.UpdateAbilityAllyEffectStatDto, abilityAllyEffectStat);
        abilityAllyEffectStat.UpdatedDate = DateTime.Now;

        await _abilityAllyEffectStatService.Update(abilityAllyEffectStat);

        UpdateAbilityAllyEffectStatResponse mappedResponse = _mapper.Map<UpdateAbilityAllyEffectStatResponse>(abilityAllyEffectStat);
        return mappedResponse;
    }
}

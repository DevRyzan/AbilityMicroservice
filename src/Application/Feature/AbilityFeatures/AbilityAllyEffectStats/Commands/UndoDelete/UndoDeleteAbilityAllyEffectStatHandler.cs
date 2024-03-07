using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityAllyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.UndoDelete;

public class UndoDeleteAbilityAllyEffectStatHandler : IRequestHandler<UndoDeleteAbilityAllyEffectStatRequest, UndoDeleteAbilityAllyEffectStatResponse>
{
    private readonly IAbilityAllyEffectStatService _abilityAllyEffectStatService;
    private readonly AbilityAllyEffectStatsBusinessRules _abilityAllyEffectStatsBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilityAllyEffectStatHandler(IAbilityAllyEffectStatService abilityAllyEffectStatService, AbilityAllyEffectStatsBusinessRules abilityAllyEffectStatsBusinessRules, IMapper mapper)
    {
        _abilityAllyEffectStatService = abilityAllyEffectStatService;
        _abilityAllyEffectStatsBusinessRules = abilityAllyEffectStatsBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilityAllyEffectStatResponse> Handle(UndoDeleteAbilityAllyEffectStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityAllyEffectStatsBusinessRules.IdShouldBeExist(request.UndoDeleteAbilityAllyEffectStatDto.Id);

        AbilityAllyEffectStat abilityAllyEffectStat = await _abilityAllyEffectStatService.GetById(request.UndoDeleteAbilityAllyEffectStatDto.Id);
        abilityAllyEffectStat.IsDeleted = false;
        abilityAllyEffectStat.UpdatedDate = DateTime.Now;

        await _abilityAllyEffectStatService.Update(abilityAllyEffectStat);

        UndoDeleteAbilityAllyEffectStatResponse mappedResponse = _mapper.Map<UndoDeleteAbilityAllyEffectStatResponse>(abilityAllyEffectStat);
        return mappedResponse;
    }
}

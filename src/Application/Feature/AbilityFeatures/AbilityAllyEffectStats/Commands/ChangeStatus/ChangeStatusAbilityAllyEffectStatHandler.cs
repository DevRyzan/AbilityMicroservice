using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityAllyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.ChangeStatus;

public class ChangeStatusAbilityAllyEffectStatHandler : IRequestHandler<ChangeStatusAbilityAllyEffectStatRequest, ChangeStatusAbilityAllyEffectStatResponse>
{
    private readonly IAbilityAllyEffectStatService _abilityAllyEffectStatService;
    private readonly AbilityAllyEffectStatsBusinessRules _abilityAllyEffectStatsBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityAllyEffectStatHandler(IAbilityAllyEffectStatService abilityAllyEffectStatService, AbilityAllyEffectStatsBusinessRules abilityAllyEffectStatsBusinessRules, IMapper mapper)
    {
        _abilityAllyEffectStatService = abilityAllyEffectStatService;
        _abilityAllyEffectStatsBusinessRules = abilityAllyEffectStatsBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityAllyEffectStatResponse> Handle(ChangeStatusAbilityAllyEffectStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityAllyEffectStatsBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityAllyEffectStatDto.Id);

        AbilityAllyEffectStat abilityAllyEffectStat = await _abilityAllyEffectStatService.GetById(request.ChangeStatusAbilityAllyEffectStatDto.Id);
        abilityAllyEffectStat.Status = abilityAllyEffectStat.Status == true ? false : true;
        abilityAllyEffectStat.UpdatedDate = DateTime.Now;

        await _abilityAllyEffectStatService.Update(abilityAllyEffectStat);

        ChangeStatusAbilityAllyEffectStatResponse mappedResponse = _mapper.Map<ChangeStatusAbilityAllyEffectStatResponse>(abilityAllyEffectStat);
        return mappedResponse;
    }
}

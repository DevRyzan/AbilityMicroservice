using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEnemyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.ChangeStatus;

public class ChangeStatusAbilityEnemyEffectStatHandler : IRequestHandler<ChangeStatusAbilityEnemyEffectStatRequest, ChangeStatusAbilityEnemyEffectStatResponse>
{
    private readonly IAbilityEnemyEffectStatService _abilityEnemyEffectStatService;
    private readonly AbilityEnemyEffectStatBusinessRules _abilityEnemyEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityEnemyEffectStatHandler(IAbilityEnemyEffectStatService abilityEnemyEffectStatService, AbilityEnemyEffectStatBusinessRules abilityEnemyEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEnemyEffectStatService = abilityEnemyEffectStatService;
        _abilityEnemyEffectStatBusinessRules = abilityEnemyEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityEnemyEffectStatResponse> Handle(ChangeStatusAbilityEnemyEffectStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityEnemyEffectStatBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityEnemyEffectStatDto.Id);

        AbilityEnemyEffectStat abilityEnemyEffectStat = await _abilityEnemyEffectStatService.GetById(request.ChangeStatusAbilityEnemyEffectStatDto.Id);
        abilityEnemyEffectStat.Status = abilityEnemyEffectStat.Status == true ? false : true;
        abilityEnemyEffectStat.UpdatedDate = DateTime.Now;

        await _abilityEnemyEffectStatService.Update(abilityEnemyEffectStat);

        ChangeStatusAbilityEnemyEffectStatResponse mappedResponse = _mapper.Map<ChangeStatusAbilityEnemyEffectStatResponse>(abilityEnemyEffectStat);
        return mappedResponse;
    }
}


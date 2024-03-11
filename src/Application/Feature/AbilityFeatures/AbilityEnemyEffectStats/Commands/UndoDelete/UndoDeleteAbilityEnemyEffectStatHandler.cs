using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEnemyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.UndoDelete;

public class UndoDeleteAbilityEnemyEffectStatHandler : IRequestHandler<UndoDeleteAbilityEnemyEffectStatRequest, UndoDeleteAbilityEnemyEffectStatResponse>
{
    private readonly IAbilityEnemyEffectStatService _abilityEnemyEffectStatService;
    private readonly AbilityEnemyEffectStatBusinessRules _abilityEnemyEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilityEnemyEffectStatHandler(IAbilityEnemyEffectStatService abilityEnemyEffectStatService, AbilityEnemyEffectStatBusinessRules abilityEnemyEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEnemyEffectStatService = abilityEnemyEffectStatService;
        _abilityEnemyEffectStatBusinessRules = abilityEnemyEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilityEnemyEffectStatResponse> Handle(UndoDeleteAbilityEnemyEffectStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityEnemyEffectStatBusinessRules.IdShouldBeExist(request.UndoDeleteAbilityEnemyEffectStatDto.Id);

        AbilityEnemyEffectStat abilityEnemyEffectStat = await _abilityEnemyEffectStatService.GetById(request.UndoDeleteAbilityEnemyEffectStatDto.Id);

        abilityEnemyEffectStat.IsDeleted = false;
        abilityEnemyEffectStat.UpdatedDate = DateTime.Now;

        await _abilityEnemyEffectStatService.Update(abilityEnemyEffectStat);

        UndoDeleteAbilityEnemyEffectStatResponse mappedResponse = _mapper.Map<UndoDeleteAbilityEnemyEffectStatResponse>(abilityEnemyEffectStat);
        return mappedResponse;
    }
}

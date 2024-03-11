using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEnemyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.Update;

public class UpdateAbilityEnemyEffectStatHandler : IRequestHandler<UpdateAbilityEnemyEffectStatRequest, UpdateAbilityEnemyEffectStatResponse>
{
    private readonly IAbilityEnemyEffectStatService _abilityEnemyEffectStatService;
    private readonly AbilityEnemyEffectStatBusinessRules _abilityEnemyEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityEnemyEffectStatHandler(IAbilityEnemyEffectStatService abilityEnemyEffectStatService, AbilityEnemyEffectStatBusinessRules abilityEnemyEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEnemyEffectStatService = abilityEnemyEffectStatService;
        _abilityEnemyEffectStatBusinessRules = abilityEnemyEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityEnemyEffectStatResponse> Handle(UpdateAbilityEnemyEffectStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityEnemyEffectStatBusinessRules.IdShouldBeExist(request.UpdateAbilityEnemyEffectStatDto.Id);

        AbilityEnemyEffectStat abilityEnemyEffectStat = await _abilityEnemyEffectStatService.GetById(request.UpdateAbilityEnemyEffectStatDto.Id);

        _mapper.Map(request.UpdateAbilityEnemyEffectStatDto, abilityEnemyEffectStat);
        abilityEnemyEffectStat.UpdatedDate = DateTime.Now;

        await _abilityEnemyEffectStatService.Update(abilityEnemyEffectStat);

        UpdateAbilityEnemyEffectStatResponse mappedResponse = _mapper.Map<UpdateAbilityEnemyEffectStatResponse>(abilityEnemyEffectStat);
        return mappedResponse;
    }
}

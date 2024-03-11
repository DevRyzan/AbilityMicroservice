using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEnemyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.Delete;

public class DeleteAbilityEnemyEffectStatHandler : IRequestHandler<DeleteAbilityEnemyEffectStatRequest, DeleteAbilityEnemyEffectStatResponse>
{
    private readonly IAbilityEnemyEffectStatService _abilityEnemyEffectStatService;
    private readonly AbilityEnemyEffectStatBusinessRules _abilityEnemyEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilityEnemyEffectStatHandler(IAbilityEnemyEffectStatService abilityEnemyEffectStatService, AbilityEnemyEffectStatBusinessRules abilityEnemyEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEnemyEffectStatService = abilityEnemyEffectStatService;
        _abilityEnemyEffectStatBusinessRules = abilityEnemyEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilityEnemyEffectStatResponse> Handle(DeleteAbilityEnemyEffectStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityEnemyEffectStatBusinessRules.IdShouldBeExist(request.DeleteAbilityEnemyEffectStatDto.Id);

        AbilityEnemyEffectStat abilityEnemyEffectStat = await _abilityEnemyEffectStatService.GetById(request.DeleteAbilityEnemyEffectStatDto.Id);
        abilityEnemyEffectStat.IsDeleted = true;
        abilityEnemyEffectStat.Status = false;
        abilityEnemyEffectStat.DeletedDate = DateTime.Now;

        await _abilityEnemyEffectStatService.Delete(abilityEnemyEffectStat);

        DeleteAbilityEnemyEffectStatResponse mappedResponse = _mapper.Map<DeleteAbilityEnemyEffectStatResponse>(abilityEnemyEffectStat);
        return mappedResponse;
    }
}

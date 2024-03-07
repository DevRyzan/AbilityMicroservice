using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityAllyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.Delete;

public class DeleteAbilityAllyEffectStatHandler : IRequestHandler<DeleteAbilityAllyEffectStatRequest, DeleteAbilityAllyEffectStatResponse>
{
    private readonly IAbilityAllyEffectStatService _abilityAllyEffectStatService;
    private readonly AbilityAllyEffectStatsBusinessRules _abilityAllyEffectStatsBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilityAllyEffectStatHandler(IAbilityAllyEffectStatService abilityAllyEffectStatService, AbilityAllyEffectStatsBusinessRules abilityAllyEffectStatsBusinessRules, IMapper mapper)
    {
        _abilityAllyEffectStatService = abilityAllyEffectStatService;
        _abilityAllyEffectStatsBusinessRules = abilityAllyEffectStatsBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilityAllyEffectStatResponse> Handle(DeleteAbilityAllyEffectStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityAllyEffectStatsBusinessRules.IdShouldBeExist(request.DeleteAbilityAllyEffectStatDto.Id);

        AbilityAllyEffectStat abilityAllyEffectStat = await _abilityAllyEffectStatService.GetById(request.DeleteAbilityAllyEffectStatDto.Id);
        abilityAllyEffectStat.IsDeleted = true;
        abilityAllyEffectStat.Status = false;
        abilityAllyEffectStat.DeletedDate = DateTime.Now;

        await _abilityAllyEffectStatService.Delete(abilityAllyEffectStat);

        DeleteAbilityAllyEffectStatResponse mappedResponse = _mapper.Map<DeleteAbilityAllyEffectStatResponse>(abilityAllyEffectStat);
        return mappedResponse;
    }
}

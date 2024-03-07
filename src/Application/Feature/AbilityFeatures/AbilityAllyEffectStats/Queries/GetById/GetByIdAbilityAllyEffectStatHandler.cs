using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityAllyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Queries.GetById;

public class GetByIdAbilityAllyEffectStatHandler : IRequestHandler<GetByIdAbilityAllyEffectStatRequest, GetByIdAbilityAllyEffectStatResponse>
{
    private readonly IAbilityAllyEffectStatService _abilityAllyEffectStatService;
    private readonly AbilityAllyEffectStatsBusinessRules _abilityAllyEffectStatsBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdAbilityAllyEffectStatHandler(IAbilityAllyEffectStatService abilityAllyEffectStatService, AbilityAllyEffectStatsBusinessRules abilityAllyEffectStatsBusinessRules, IMapper mapper)
    {
        _abilityAllyEffectStatService = abilityAllyEffectStatService;
        _abilityAllyEffectStatsBusinessRules = abilityAllyEffectStatsBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdAbilityAllyEffectStatResponse> Handle(GetByIdAbilityAllyEffectStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityAllyEffectStatsBusinessRules.IdShouldBeExist(request.GetByIdAbilityAllyEffectStatDto.Id);

        AbilityAllyEffectStat abilityAllyEffectStat = await _abilityAllyEffectStatService.GetById(request.GetByIdAbilityAllyEffectStatDto.Id);

        ChangeStatusAbilityAllyEffectStatResponse mappedResponse = _mapper.Map<ChangeStatusAbilityAllyEffectStatResponse>(abilityAllyEffectStat);
        return mappedResponse;
    }
}

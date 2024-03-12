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
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityAllyEffectStatsBusinessRules.IdShouldBeExist(request.GetByIdAbilityAllyEffectStatDto.Id);

        // Retrieve the AbilityAllyEffectStat associated with the provided ID from the service.
        AbilityAllyEffectStat abilityAllyEffectStat = await _abilityAllyEffectStatService.GetById(request.GetByIdAbilityAllyEffectStatDto.Id);

        // Map the retrieved AbilityAllyEffectStat to the response DTO.
        GetByIdAbilityAllyEffectStatResponse mappedResponse = _mapper.Map<GetByIdAbilityAllyEffectStatResponse>(abilityAllyEffectStat);

        // Return the mapped response.
        return mappedResponse;

    }
}

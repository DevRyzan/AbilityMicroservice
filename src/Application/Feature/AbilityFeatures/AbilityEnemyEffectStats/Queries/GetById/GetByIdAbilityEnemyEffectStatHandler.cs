using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEnemyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Queries.GetById;

public class GetByIdAbilityEnemyEffectStatHandler : IRequestHandler<GetByIdAbilityEnemyEffectStatRequest, GetByIdAbilityEnemyEffectStatResponse>
{
    private readonly IAbilityEnemyEffectStatService _abilityEnemyEffectStatService;
    private readonly AbilityEnemyEffectStatBusinessRules _abilityEnemyEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdAbilityEnemyEffectStatHandler(IAbilityEnemyEffectStatService abilityEnemyEffectStatService, AbilityEnemyEffectStatBusinessRules abilityEnemyEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEnemyEffectStatService = abilityEnemyEffectStatService;
        _abilityEnemyEffectStatBusinessRules = abilityEnemyEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdAbilityEnemyEffectStatResponse> Handle(GetByIdAbilityEnemyEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ID exists before attempting to retrieve the AbilityEnemyEffectStat
        await _abilityEnemyEffectStatBusinessRules.IdShouldBeExist(request.GetByIdAbilityEnemyEffectStatDto.Id);

        // Retrieve the AbilityEnemyEffectStat using the specified ID
        AbilityEnemyEffectStat abilityEnemyEffectStat = await _abilityEnemyEffectStatService.GetById(request.GetByIdAbilityEnemyEffectStatDto.Id);

        // Map the retrieved AbilityEnemyEffectStat to the response DTO
        GetByIdAbilityEnemyEffectStatResponse mappedResponse = _mapper.Map<GetByIdAbilityEnemyEffectStatResponse>(abilityEnemyEffectStat);

        // Return the mapped response
        return mappedResponse;

    }
}

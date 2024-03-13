using Application.Feature.AbilityFeatures.AbilityEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Queries.GetById;

public class GetByIdAbilityEffectStatHandler : IRequestHandler<GetByIdAbilityEffectStatRequest, GetByIdAbilityEffectStatResponse>
{
    private readonly IAbilityEffectStatService _abilityEffectStatService;
    private readonly AbilityEffectStatBusinessRules _abilityEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdAbilityEffectStatHandler(IAbilityEffectStatService abilityEffectStatService, AbilityEffectStatBusinessRules abilityEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEffectStatService = abilityEffectStatService;
        _abilityEffectStatBusinessRules = abilityEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdAbilityEffectStatResponse> Handle(GetByIdAbilityEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Check if the ID exists using business rules.
        await _abilityEffectStatBusinessRules.IdShouldBeExist(request.GetByIdAbilityEffectStatDto.Id);

        // Get the AbilityEffectStat entity by ID.
        AbilityEffectStat abilityEffectStat = await _abilityEffectStatService.GetById(request.GetByIdAbilityEffectStatDto.Id);

        // Map the retrieved AbilityEffectStat entity to the response DTO.
        GetByIdAbilityEffectStatResponse mappedResponse = _mapper.Map<GetByIdAbilityEffectStatResponse>(abilityEffectStat);

        // Return the mapped response.
        return mappedResponse;

    }
}

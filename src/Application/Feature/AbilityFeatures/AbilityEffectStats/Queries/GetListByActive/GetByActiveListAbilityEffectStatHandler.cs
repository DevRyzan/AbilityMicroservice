using Application.Feature.AbilityFeatures.AbilityEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Queries.GetListByActive;

public class GetByActiveListAbilityEffectStatHandler : IRequestHandler<GetByActiveListAbilityEffectStatRequest, List<GetByActiveListAbilityEffectStatResponse>>
{
    private readonly IAbilityEffectStatService _abilityEffectStatService;
    private readonly AbilityEffectStatBusinessRules _abilityEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public GetByActiveListAbilityEffectStatHandler(IAbilityEffectStatService abilityEffectStatService, AbilityEffectStatBusinessRules abilityEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEffectStatService = abilityEffectStatService;
        _abilityEffectStatBusinessRules = abilityEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetByActiveListAbilityEffectStatResponse>> Handle(GetByActiveListAbilityEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the page request is valid using business rules.
        await _abilityEffectStatBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Get the list of AbilityEffectStat entities by active status, paginated.
        List<AbilityEffectStat> abilityEffectTypes = await _abilityEffectStatService.GetListByActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list to the corresponding response DTOs.
        List<GetByActiveListAbilityEffectStatResponse> mappedResponse = _mapper.Map<List<GetByActiveListAbilityEffectStatResponse>>(abilityEffectTypes);

        // Return the mapped response.
        return mappedResponse;

    }
}

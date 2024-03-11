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
        await _abilityEffectStatBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<AbilityEffectStat> abilityEffectTypes = await _abilityEffectStatService.GetListByActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<GetByActiveListAbilityEffectStatResponse> mappedResponse = _mapper.Map<List<GetByActiveListAbilityEffectStatResponse>>(abilityEffectTypes);
        return mappedResponse;
    }
}

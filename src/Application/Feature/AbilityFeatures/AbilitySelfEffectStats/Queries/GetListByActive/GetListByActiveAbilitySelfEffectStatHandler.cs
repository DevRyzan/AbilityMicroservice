using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Rules;
using Application.Service.AbilityServices.AbilitySelfEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Queries.GetListByActive;

public class GetListByActiveAbilitySelfEffectStatHandler : IRequestHandler<GetListByActiveAbilitySelfEffectStatRequest, List<GetListByActiveAbilitySelfEffectStatResponse>>
{
    private readonly IAbilitySelfEffectStatService _abilitySelfEffectStatService;
    private readonly AbilitySelfEffectStatBusinessRules _abilitySelfEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public GetListByActiveAbilitySelfEffectStatHandler(IAbilitySelfEffectStatService abilitySelfEffectStatService, AbilitySelfEffectStatBusinessRules abilitySelfEffectStatBusinessRules, IMapper mapper)
    {
        _abilitySelfEffectStatService = abilitySelfEffectStatService;
        _abilitySelfEffectStatBusinessRules = abilitySelfEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByActiveAbilitySelfEffectStatResponse>> Handle(GetListByActiveAbilitySelfEffectStatRequest request, CancellationToken cancellationToken)
    {
        await _abilitySelfEffectStatBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<AbilitySelfEffectStat> abilitySelfEffectStatList = await _abilitySelfEffectStatService.GetListByActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<GetListByActiveAbilitySelfEffectStatResponse> mappedResponse = _mapper.Map<List<GetListByActiveAbilitySelfEffectStatResponse>>(abilitySelfEffectStatList);
        return mappedResponse;
    }
}

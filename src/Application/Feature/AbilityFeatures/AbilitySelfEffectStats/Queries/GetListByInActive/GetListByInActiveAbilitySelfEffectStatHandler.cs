using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Rules;
using Application.Service.AbilityServices.AbilitySelfEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Queries.GetListByInActive;

public class GetListByInActiveAbilitySelfEffectStatHandler : IRequestHandler<GetListByInActiveAbilitySelfEffectStatRequest, List<GetListByInActiveAbilitySelfEffectStatResponse>>
{
    private readonly IAbilitySelfEffectStatService _abilitySelfEffectStatService;
    private readonly AbilitySelfEffectStatBusinessRules _abilitySelfEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public GetListByInActiveAbilitySelfEffectStatHandler(IAbilitySelfEffectStatService abilitySelfEffectStatService, AbilitySelfEffectStatBusinessRules abilitySelfEffectStatBusinessRules, IMapper mapper)
    {
        _abilitySelfEffectStatService = abilitySelfEffectStatService;
        _abilitySelfEffectStatBusinessRules = abilitySelfEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByInActiveAbilitySelfEffectStatResponse>> Handle(GetListByInActiveAbilitySelfEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the provided page request is valid before proceeding
        await _abilitySelfEffectStatBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of inactive AbilitySelfEffectStat entities using the provided page index and size
        List<AbilitySelfEffectStat> abilitySelfEffectStatList = await _abilitySelfEffectStatService.GetListByInActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of entities to the corresponding response DTOs
        List<GetListByInActiveAbilitySelfEffectStatResponse> mappedResponse = _mapper.Map<List<GetListByInActiveAbilitySelfEffectStatResponse>>(abilitySelfEffectStatList);

        // Return the mapped response
        return mappedResponse;

    }
}

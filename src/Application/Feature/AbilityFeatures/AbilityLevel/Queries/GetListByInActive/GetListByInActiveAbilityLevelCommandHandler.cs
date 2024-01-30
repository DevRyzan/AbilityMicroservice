using Application.Feature.AbilityFeatures.AbilityLevel.Rules;
using Application.Service.AbilityServices.AbilityLevelService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Queries.GetListByInActive;

public class GetListByInActiveAbilityLevelCommandHandler : IRequestHandler<GetListByInActiveAbilityLevelCommandRequest, List<GetListByInActiveAbilityLevelCommandResponse>>
{
    private readonly IAbilityLevelService _abilityLevelService;
    private readonly IMapper _mapper;
    private readonly AbilityLevelBusinessRules _abilityLevelBusinessRules;

    public GetListByInActiveAbilityLevelCommandHandler(IAbilityLevelService abilityLevelService, IMapper mapper, AbilityLevelBusinessRules abilityLevelBusinessRules)
    {
        _abilityLevelService = abilityLevelService;
        _mapper = mapper;
        _abilityLevelBusinessRules = abilityLevelBusinessRules;
    }

    public async Task<List<GetListByInActiveAbilityLevelCommandResponse>> Handle(GetListByInActiveAbilityLevelCommandRequest request, CancellationToken cancellationToken)
    {

        // Validate that the page request parameters (index and size) are valid.
        await _abilityLevelBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of inactive AbilityLevels based on the provided index and page size.
        List<Domain.Abilities.AbilityLevel> abilityLevels = await _abilityLevelService.GetListByInActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of AbilityLevels to a list of response objects for inactive levels.
        List<GetListByInActiveAbilityLevelCommandResponse> mappedResponse = _mapper.Map<List<GetListByInActiveAbilityLevelCommandResponse>>(abilityLevels);

        // Return the mapped response.
        return mappedResponse;

    }
}

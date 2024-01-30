using Application.Feature.AbilityFeatures.AbilityLevel.Rules;
using Application.Service.AbilityServices.AbilityLevelService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Queries.GetListByActive;

public class GetListByActiveAbilityLevelCommandHandler : IRequestHandler<GetListByActiveAbilityLevelCommandRequest, List<GetListByActiveAbilityLevelCommandResponse>>
{
    private readonly IAbilityLevelService _abilityLevelService;
    private readonly IMapper _mapper;
    private readonly AbilityLevelBusinessRules _abilityLevelBusinessRules;

    public GetListByActiveAbilityLevelCommandHandler(IAbilityLevelService abilityLevelService, IMapper mapper, AbilityLevelBusinessRules abilityLevelBusinessRules)
    {
        _abilityLevelService = abilityLevelService;
        _mapper = mapper;
        _abilityLevelBusinessRules = abilityLevelBusinessRules;
    }

    public async Task<List<GetListByActiveAbilityLevelCommandResponse>> Handle(GetListByActiveAbilityLevelCommandRequest request, CancellationToken cancellationToken)
    {
        // Validate that the page request parameters (index and size) are valid.
        await _abilityLevelBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of active AbilityLevels based on the provided index and page size.
        List<Domain.Abilities.AbilityLevel> abilityLevels = await _abilityLevelService.GetListByActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of AbilityLevels to a list of response objects for active levels.
        List<GetListByActiveAbilityLevelCommandResponse> mappedResponse = _mapper.Map<List<GetListByActiveAbilityLevelCommandResponse>>(abilityLevels);

        // Return the mapped response.
        return mappedResponse;


    }
}

using Application.Feature.AbilityFeatures.AbilityCombo.Rules;
using Application.Service.AbilityServices.AbilityComboService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Queries.GetListByInActive;

public class GetListByInActiveAbilityComboQueryHandler : IRequestHandler<GetListByInActiveAbilityComboQueryRequest, List<GetListByInActiveAbilityComboQueryResponse>>
{
    private readonly IAbilityComboService _abilityComboService;
    private readonly AbilityComboBusinessRules _abilityComboBusinessRules;
    private readonly IMapper _mapper;

    public GetListByInActiveAbilityComboQueryHandler(IAbilityComboService abilityComboService, AbilityComboBusinessRules abilityComboBusinessRules, IMapper mapper)
    {
        _abilityComboService = abilityComboService;
        _abilityComboBusinessRules = abilityComboBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByInActiveAbilityComboQueryResponse>> Handle(GetListByInActiveAbilityComboQueryRequest request, CancellationToken cancellationToken)
    {
        // Validate that the page request parameters (index and size) are valid.
        await _abilityComboBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of inactive AbilityCombos based on the provided index and page size.
        List<Domain.Abilities.AbilityCombo> abilityCombos = await _abilityComboService.GetListByInActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of AbilityCombos to a list of response objects for inactive combos.
        List<GetListByInActiveAbilityComboQueryResponse> mappedResponse = _mapper.Map<List<GetListByInActiveAbilityComboQueryResponse>>(abilityCombos);

        // Return the mapped response.
        return mappedResponse;

    }
}

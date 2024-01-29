using Application.Feature.AbilityFeatures.AbilityCombo.Rules;
using Application.Service.AbilityServices.AbilityComboService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Queries.GetListByActive;

public class GetListByActiveAbilityComboQueryHandler : IRequestHandler<GetListByActiveAbilityComboQueryRequest, List<GetListByActiveAbilityComboQueryResponse>>
{
    private readonly IAbilityComboService _abilityComboService;
    private readonly AbilityComboBusinessRules _abilityComboBusinessRules;
    private readonly IMapper _mapper;

    public GetListByActiveAbilityComboQueryHandler(IAbilityComboService abilityComboService, AbilityComboBusinessRules abilityComboBusinessRules, IMapper mapper)
    {
        _abilityComboService = abilityComboService;
        _abilityComboBusinessRules = abilityComboBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByActiveAbilityComboQueryResponse>> Handle(GetListByActiveAbilityComboQueryRequest request, CancellationToken cancellationToken)
    {
        // Validate that the page request parameters (index and size) are valid.
        await _abilityComboBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of active AbilityCombos based on the provided index and page size.
        List<Domain.Abilities.AbilityCombo> abilityCombos = await _abilityComboService.GetListByActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of AbilityCombos to a list of response objects.
        List<GetListByActiveAbilityComboQueryResponse> mappedResponse = _mapper.Map<List<GetListByActiveAbilityComboQueryResponse>>(abilityCombos);

        // Return the mapped response.
        return mappedResponse;


    }
}

using Application.Feature.AbilityFeatures.AbilityAffectUnits.Rules;
using Application.Service.AbilityServices.AbilityAffectUnitService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Queries.GetListByInActive;

public class GetListByInActiveAbilityAffectUnitHandler : IRequestHandler<GetListByInActiveAbilityAffectUnitRequest, List<GetListByInActiveAbilityAffectUnitResponse>>
{
    private readonly IAbilityAffectUnitService _abilityAffectUnitService;
    private readonly AbilityAffectUnitBusinessRules _abilityAffectUnitBusinessRules;
    private readonly IMapper _mapper;

    public GetListByInActiveAbilityAffectUnitHandler(IAbilityAffectUnitService abilityAffectUnitService, AbilityAffectUnitBusinessRules abilityAffectUnitBusinessRules, IMapper mapper)
    {
        _abilityAffectUnitService = abilityAffectUnitService;
        _abilityAffectUnitBusinessRules = abilityAffectUnitBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByInActiveAbilityAffectUnitResponse>> Handle(GetListByInActiveAbilityAffectUnitRequest request, CancellationToken cancellationToken)
    {
        // Check the validity of the page request; it should comply with business rules.
        await _abilityAffectUnitBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of inactive AbilityAffectUnits based on the active page and page size.
        List<AbilityAffectUnit> abilityAffectUnitList = await _abilityAffectUnitService.GetListByInActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of inactive AbilityAffectUnits to the response DTO list.
        List<GetListByInActiveAbilityAffectUnitResponse> mappedResponse = _mapper.Map<List<GetListByInActiveAbilityAffectUnitResponse>>(abilityAffectUnitList);

        // Return the mapped response.
        return mappedResponse;

    }
}

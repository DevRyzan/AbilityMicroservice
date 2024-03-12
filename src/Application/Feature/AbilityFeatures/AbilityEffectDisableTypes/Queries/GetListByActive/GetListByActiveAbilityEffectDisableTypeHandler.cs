using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectDisableTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Queries.GetListByActive;

public class GetListByActiveAbilityEffectDisableTypeHandler : IRequestHandler<GetListByActiveAbilityEffectDisableTypeRequest, List<GetListByActiveAbilityEffectDisableTypeResponse>>
{
    private readonly IAbilityEffectDisableTypeService _abilityEffectDisableTypeService;
    private readonly AbilityEffectDisableTypeBusinessRules _abilityEffectDisableTypeBusinessRules;
    private readonly IMapper _mapper;

    public GetListByActiveAbilityEffectDisableTypeHandler(IAbilityEffectDisableTypeService abilityEffectDisableTypeService, AbilityEffectDisableTypeBusinessRules abilityEffectDisableTypeBusinessRules, IMapper mapper)
    {
        _abilityEffectDisableTypeService = abilityEffectDisableTypeService;
        _abilityEffectDisableTypeBusinessRules = abilityEffectDisableTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByActiveAbilityEffectDisableTypeResponse>> Handle(GetListByActiveAbilityEffectDisableTypeRequest request, CancellationToken cancellationToken)
    {
        // Check the validity of the page request; it should comply with business rules.
        await _abilityEffectDisableTypeBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of active AbilityEffectDisableTypes based on the specified page parameters.
        List<AbilityEffectDisableType> abilityEffectDisableTypeList = await _abilityEffectDisableTypeService.GetListByActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of AbilityEffectDisableTypes to the response DTOs.
        List<GetListByActiveAbilityEffectDisableTypeResponse> mappedResponse = _mapper.Map<List<GetListByActiveAbilityEffectDisableTypeResponse>>(abilityEffectDisableTypeList);

        // Return the mapped response.
        return mappedResponse;

    }
}

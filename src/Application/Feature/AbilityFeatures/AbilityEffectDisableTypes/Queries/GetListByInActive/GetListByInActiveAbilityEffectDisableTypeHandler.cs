using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectDisableTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Queries.GetListByInActive;

public class GetListByInActiveAbilityEffectDisableTypeHandler : IRequestHandler<GetListByInActiveAbilityEffectDisableTypeRequest, List<GetListByInActiveAbilityEffectDisableTypeResponse>>
{
    private readonly IAbilityEffectDisableTypeService _abilityEffectDisableTypeService;
    private readonly AbilityEffectDisableTypeBusinessRules _abilityEffectDisableTypeBusinessRules;
    private readonly IMapper _mapper;

    public GetListByInActiveAbilityEffectDisableTypeHandler(IAbilityEffectDisableTypeService abilityEffectDisableTypeService, AbilityEffectDisableTypeBusinessRules abilityEffectDisableTypeBusinessRules, IMapper mapper)
    {
        _abilityEffectDisableTypeService = abilityEffectDisableTypeService;
        _abilityEffectDisableTypeBusinessRules = abilityEffectDisableTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByInActiveAbilityEffectDisableTypeResponse>> Handle(GetListByInActiveAbilityEffectDisableTypeRequest request, CancellationToken cancellationToken)
    {
        // Check the validity of the page request; it should comply with business rules.
        await _abilityEffectDisableTypeBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of inactive AbilityEffectDisableTypes based on the specified page parameters.
        List<AbilityEffectDisableType> abilityEffectDisableTypeList = await _abilityEffectDisableTypeService.GetListByInActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of AbilityEffectDisableTypes to the response DTOs.
        List<GetListByInActiveAbilityEffectDisableTypeResponse> mappedResponse = _mapper.Map<List<GetListByInActiveAbilityEffectDisableTypeResponse>>(abilityEffectDisableTypeList);

        // Return the mapped response.
        return mappedResponse;

    }
}

using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Service.AbilityServices.AbilityActivationTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Queries.GetListByActive;

public class GetListByActiveAbilityActivationTypeHandler : IRequestHandler<GetListByActiveAbilityActivationTypeRequest, List<GetListByActiveAbilityActivationTypeResponse>>
{
    private readonly IAbilityActivationTypeService _abilityActivationTypeService;
    private readonly AbilityActivationTypeBusinessRules _abilityActivationTypeBusinessRules;
    private readonly IMapper _mapper;

    public GetListByActiveAbilityActivationTypeHandler(IAbilityActivationTypeService abilityActivationTypeService, AbilityActivationTypeBusinessRules abilityActivationTypeBusinessRules, IMapper mapper)
    {
        _abilityActivationTypeService = abilityActivationTypeService;
        _abilityActivationTypeBusinessRules = abilityActivationTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByActiveAbilityActivationTypeResponse>> Handle(GetListByActiveAbilityActivationTypeRequest request, CancellationToken cancellationToken)
    {
        // Check the validity of the page request; it should comply with business rules.
        await _abilityActivationTypeBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of AbilityActivationTypes based on the active page and page size.
        List<AbilityActivationType> abilityActivationTypeList = await _abilityActivationTypeService.GetListByActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of AbilityActivationTypes to the response DTO list.
        List<GetListByActiveAbilityActivationTypeResponse> mappedResponse = _mapper.Map<List<GetListByActiveAbilityActivationTypeResponse>>(abilityActivationTypeList);

        // Return the mapped response.
        return mappedResponse;

    }
}

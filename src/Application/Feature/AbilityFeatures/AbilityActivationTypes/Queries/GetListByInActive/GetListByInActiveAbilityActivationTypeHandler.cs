using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Service.AbilityServices.AbilityActivationTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Queries.GetListByInActive;

public class GetListByInActiveAbilityActivationTypeHandler : IRequestHandler<GetListByInActiveAbilityActivationTypeRequest, List<GetListByInActiveAbilityActivationTypeResponse>>
{
    private readonly IAbilityActivationTypeService _abilityActivationTypeService;
    private readonly AbilityActivationTypeBusinessRules _abilityActivationTypeBusinessRules;
    private readonly IMapper _mapper;

    public GetListByInActiveAbilityActivationTypeHandler(IAbilityActivationTypeService abilityActivationTypeService, AbilityActivationTypeBusinessRules abilityActivationTypeBusinessRules, IMapper mapper)
    {
        _abilityActivationTypeService = abilityActivationTypeService;
        _abilityActivationTypeBusinessRules = abilityActivationTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByInActiveAbilityActivationTypeResponse>> Handle(GetListByInActiveAbilityActivationTypeRequest request, CancellationToken cancellationToken)
    {
        // Check the validity of the page request; it should comply with business rules.
        await _abilityActivationTypeBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of inactive AbilityActivationTypes based on the active page and page size.
        List<AbilityActivationType> abilityActivationTypeList = await _abilityActivationTypeService.GetListByInActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of inactive AbilityActivationTypes to the response DTO list.
        List<GetListByInActiveAbilityActivationTypeResponse> mappedResponse = _mapper.Map<List<GetListByInActiveAbilityActivationTypeResponse>>(abilityActivationTypeList);

        // Return the mapped response.
        return mappedResponse;

    }
}

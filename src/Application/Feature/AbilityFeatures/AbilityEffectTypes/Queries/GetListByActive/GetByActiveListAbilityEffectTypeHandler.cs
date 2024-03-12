using Application.Feature.AbilityFeatures.AbilityEffectTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Queries.GetListByActive;

public class GetByActiveListAbilityEffectTypeHandler : IRequestHandler<GetByActiveListAbilityEffectTypeRequest, List<GetByActiveListAbilityEffectTypeResponse>>
{
    private readonly IAbilityEffectTypeService _abilityTypeService;
    private readonly AbilityEffectTypeBusinessRules _abilityEffectTypeBusinessRules;
    private readonly IMapper _mapper;

    public GetByActiveListAbilityEffectTypeHandler(IAbilityEffectTypeService abilityTypeService, AbilityEffectTypeBusinessRules abilityEffectTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityEffectTypeBusinessRules = abilityEffectTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetByActiveListAbilityEffectTypeResponse>> Handle(GetByActiveListAbilityEffectTypeRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the provided page request is valid according to business rules
        await _abilityEffectTypeBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of active AbilityEffectTypes from the service based on the provided page request
        List<AbilityEffectType> abilityEffectTypes = await _abilityTypeService.GetListByActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of AbilityEffectTypes to the response DTOs
        List<GetByActiveListAbilityEffectTypeResponse> mappedResponse = _mapper.Map<List<GetByActiveListAbilityEffectTypeResponse>>(abilityEffectTypes);

        // Return the mapped response
        return mappedResponse;

    }
}

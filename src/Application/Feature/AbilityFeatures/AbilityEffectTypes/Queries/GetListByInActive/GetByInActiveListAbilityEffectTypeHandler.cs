using Application.Feature.AbilityFeatures.AbilityEffectTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;



namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Queries.GetListByInActive;

public class GetByInActiveListAbilityEffectTypeHandler : IRequestHandler<GetByInActiveListAbilityEffectTypeRequest, List<GetByInActiveListAbilityEffectTypeResponse>>
{
    private readonly IAbilityEffectTypeService _abilityTypeService;
    private readonly AbilityEffectTypeBusinessRules _abilityEffectTypeBusinessRules;
    private readonly IMapper _mapper;

    public GetByInActiveListAbilityEffectTypeHandler(IAbilityEffectTypeService abilityTypeService, AbilityEffectTypeBusinessRules abilityEffectTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityEffectTypeBusinessRules = abilityEffectTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetByInActiveListAbilityEffectTypeResponse>> Handle(GetByInActiveListAbilityEffectTypeRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the provided page request is valid according to business rules
        await _abilityEffectTypeBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of inactive AbilityEffectTypes from the service based on the provided page request
        List<AbilityEffectType> abilityEffectTypes = await _abilityTypeService.GetListByInActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of AbilityEffectTypes to the response DTOs
        List<GetByInActiveListAbilityEffectTypeResponse> mappedResponse = _mapper.Map<List<GetByInActiveListAbilityEffectTypeResponse>>(abilityEffectTypes);

        // Return the mapped response
        return mappedResponse;

    }
}

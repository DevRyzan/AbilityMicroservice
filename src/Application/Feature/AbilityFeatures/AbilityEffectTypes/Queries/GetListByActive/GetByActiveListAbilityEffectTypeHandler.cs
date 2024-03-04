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
        await _abilityEffectTypeBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<AbilityEffectType> abilityEffectTypes = await _abilityTypeService.GetListByActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<GetByActiveListAbilityEffectTypeResponse> mappedResponse = _mapper.Map<List<GetByActiveListAbilityEffectTypeResponse>>(abilityEffectTypes);
        return mappedResponse;
    }
}

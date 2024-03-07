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
        await _abilityActivationTypeBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<AbilityActivationType> abilityActivationTypeList = await _abilityActivationTypeService.GetListByActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<GetListByActiveAbilityActivationTypeResponse> mappedResponse = _mapper.Map<List<GetListByActiveAbilityActivationTypeResponse>>(abilityActivationTypeList);
        return mappedResponse;
    }
}

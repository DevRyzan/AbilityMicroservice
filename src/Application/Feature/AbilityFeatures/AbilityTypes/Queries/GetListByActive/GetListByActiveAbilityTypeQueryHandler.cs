using Application.Feature.AbilityFeatures.AbilityTypes.Rules;
using Application.Service.AbilityServices.AbilityTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityTypes.Queries.GetListByActive;

public class GetListByActiveAbilityTypeQueryHandler : IRequestHandler<GetListByActiveAbilityTypeQueryRequest, List<GetListByActiveAbilityTypeQueryResponse>>
{
    private readonly IAbilityTypeService _abilityTypeService;
    private readonly AbilityTypeBusinessRules _abilityTypeBusinessRules;
    private readonly IMapper _mapper;

    public GetListByActiveAbilityTypeQueryHandler(IAbilityTypeService abilityTypeService, AbilityTypeBusinessRules abilityTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityTypeBusinessRules = abilityTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<List<GetListByActiveAbilityTypeQueryResponse>> Handle(GetListByActiveAbilityTypeQueryRequest request, CancellationToken cancellationToken)
    {
        await _abilityTypeBusinessRules.PageRequestShouldBeValid(request.PageRequest.Page, request.PageRequest.PageSize);

        List<AbilityType> listOfAbilityType = await _abilityTypeService.GetActiveList(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<GetListByActiveAbilityTypeQueryResponse> mappedResponse = _mapper.Map<List<GetListByActiveAbilityTypeQueryResponse>>(listOfAbilityType);
        return mappedResponse;

    }
}

using Application.Feature.AbilityFeatures.AbilityTypes.Rules;
using Application.Service.AbilityServices.AbilityTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityTypes.Queries.GetListByInActive;

public class GetListByInActiveAbilityTypeQueryHandler : IRequestHandler<GetListByInActiveAbilityTypeQueryRequest, List<GetListByInActiveAbilityTypeQueryResponse>>
{
    private readonly IAbilityTypeService _abilityTypeService;
    private readonly AbilityTypeBusinessRules _abilityTypeBusinessRules;
    private readonly IMapper _mapper;

    public GetListByInActiveAbilityTypeQueryHandler(IAbilityTypeService abilityTypeService, AbilityTypeBusinessRules abilityTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityTypeBusinessRules = abilityTypeBusinessRules;
        _mapper = mapper; 
    }

    public async Task<List<GetListByInActiveAbilityTypeQueryResponse>> Handle(GetListByInActiveAbilityTypeQueryRequest request, CancellationToken cancellationToken)
    {
        await _abilityTypeBusinessRules.PageRequestShouldBeValid(request.PageRequest.Page, request.PageRequest.PageSize);

        List<AbilityType> listOfAbilityType = await _abilityTypeService.GetInActiveList(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        List<GetListByInActiveAbilityTypeQueryResponse> mappedResponse = _mapper.Map<List<GetListByInActiveAbilityTypeQueryResponse>>(listOfAbilityType);
        return mappedResponse;
    }
}


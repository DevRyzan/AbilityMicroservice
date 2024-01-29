using Application.Feature.AbilityFeatures.AbilityCategory.Rules;
using Application.Service.AbilityServices.AbilityCategoryDetailEngService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetListByActive;

public class GetListByActiveAbilityCategoryQueryHandler : IRequestHandler<GetListByActiveAbilityCategoryQueryRequest, List<GetListByActiveAbilityCategoryQueryResponse>>
{
    private readonly IAbilityCategoryDetailEngService _abilityCategoryDetailEngService;
    private readonly IMapper _mapper;
    private readonly AbilityCategoryBusinessRules _abilityCategoryBusinessRules;

    public GetListByActiveAbilityCategoryQueryHandler(IAbilityCategoryDetailEngService abilityCategoryDetailEngService, IMapper mapper, AbilityCategoryBusinessRules abilityCategoryBusinessRules)
    {
        _abilityCategoryDetailEngService = abilityCategoryDetailEngService;
        _mapper = mapper;
        _abilityCategoryBusinessRules = abilityCategoryBusinessRules;
    }

    public async Task<List<GetListByActiveAbilityCategoryQueryResponse>> Handle(GetListByActiveAbilityCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        await _abilityCategoryBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize); 

        // Retrieve a paginated list of active AbilityCategoryDetailEng based on the provided index and page size.
        List<AbilityCategoryDetailEng> paginate = await _abilityCategoryDetailEngService.GetListByActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of AbilityCategoryDetailEng to a list of response objects.
        List<GetListByActiveAbilityCategoryQueryResponse> mappedResponse = _mapper.Map<List<GetListByActiveAbilityCategoryQueryResponse>>(paginate);

        // Return the mapped response.
        return mappedResponse;

    }
}

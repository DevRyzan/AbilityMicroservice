using Application.Feature.AbilityFeatures.AbilityCategory.Rules;
using Application.Service.AbilityServices.AbilityCategoryDetailEngService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetListByInActive;

public class GetListByInActiveAbilityCategoryQueryHandler : IRequestHandler<GetListByInActiveAbilityCategoryQueryRequest, List<GetListByInActiveAbilityCategoryQueryResponse>>
{
    private readonly IAbilityCategoryDetailEngService _abilityCategoryDetailEngService;
    private readonly IMapper _mapper;
    private readonly AbilityCategoryBusinessRules _abilityCategoryBusinessRules;

    public GetListByInActiveAbilityCategoryQueryHandler(IAbilityCategoryDetailEngService abilityCategoryDetailEngService, IMapper mapper, AbilityCategoryBusinessRules abilityCategoryBusinessRules)
    {
        _abilityCategoryDetailEngService = abilityCategoryDetailEngService;
        _mapper = mapper;
        _abilityCategoryBusinessRules = abilityCategoryBusinessRules;
    }

    public async Task<List<GetListByInActiveAbilityCategoryQueryResponse>> Handle(GetListByInActiveAbilityCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        await _abilityCategoryBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a paginated list of inactive AbilityCategoryDetailEng based on the provided index and page size.
        List<AbilityCategoryDetailEng> paginate = await _abilityCategoryDetailEngService.GetListByInActive(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of AbilityCategoryDetailEng to a list of response objects for inactive categories.
        List<GetListByInActiveAbilityCategoryQueryResponse> mappedResponse = _mapper.Map<List<GetListByInActiveAbilityCategoryQueryResponse>>(paginate);

        // Return the mapped response.
        return mappedResponse;

    }
}

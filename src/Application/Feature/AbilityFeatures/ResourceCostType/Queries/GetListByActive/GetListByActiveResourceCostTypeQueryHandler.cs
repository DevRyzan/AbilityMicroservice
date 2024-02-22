using Application.Feature.AbilityFeatures.ResourceCostType.Rules;
using Application.Service.AbilityServices.ResourceCostTypeService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.ResourceCostType.Queries.GetListByActive;

public class GetListByActiveResourceCostTypeQueryHandler : IRequestHandler<GetListByActiveResourceCostTypeQueryRequest, List<GetListByActiveResourceCostTypeQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IResourceCostTypeService _resourceCostTypeService;
    private readonly ResourceCostTypeBusinessRules _resourceCostTypeBusinessRules;

    public GetListByActiveResourceCostTypeQueryHandler(IMapper mapper, IResourceCostTypeService resourceCostTypeService, ResourceCostTypeBusinessRules resourceCostTypeBusinessRules)
    {
        _mapper = mapper;
        _resourceCostTypeService = resourceCostTypeService;
        _resourceCostTypeBusinessRules = resourceCostTypeBusinessRules;
    }

    public async Task<List<GetListByActiveResourceCostTypeQueryResponse>> Handle(GetListByActiveResourceCostTypeQueryRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the page request (index and size) provided is valid
        await _resourceCostTypeBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of active resource cost types from the service based on the page request
        List<Domain.Abilities.ResourceCostType> resourceCostTypes = await _resourceCostTypeService.GetActiveList(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of active resource cost types to the response objects
        List<GetListByActiveResourceCostTypeQueryResponse> mappedResponse = _mapper.Map<List<GetListByActiveResourceCostTypeQueryResponse>>(resourceCostTypes);

        // Return the mapped response
        return mappedResponse;


    }
}

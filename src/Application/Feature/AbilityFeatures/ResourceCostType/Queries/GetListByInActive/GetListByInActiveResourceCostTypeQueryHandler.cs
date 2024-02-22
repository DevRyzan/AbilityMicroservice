using Application.Feature.AbilityFeatures.ResourceCostType.Rules;
using Application.Service.AbilityServices.ResourceCostTypeService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.ResourceCostType.Queries.GetListByInActive;

public class GetListByInActiveResourceCostTypeQueryHandler : IRequestHandler<GetListByInActiveResourceCostTypeQueryRequest, List<GetListByInActiveResourceCostTypeQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IResourceCostTypeService _resourceCostTypeService;
    private readonly ResourceCostTypeBusinessRules _resourceCostTypeBusinessRules;

    public GetListByInActiveResourceCostTypeQueryHandler(IMapper mapper, IResourceCostTypeService resourceCostTypeService, ResourceCostTypeBusinessRules resourceCostTypeBusinessRules)
    {
        _mapper = mapper;
        _resourceCostTypeService = resourceCostTypeService;
        _resourceCostTypeBusinessRules = resourceCostTypeBusinessRules;
    }

    public async Task<List<GetListByInActiveResourceCostTypeQueryResponse>> Handle(GetListByInActiveResourceCostTypeQueryRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the page request (index and size) provided is valid
        await _resourceCostTypeBusinessRules.PageRequestShouldBeValid(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Retrieve a list of inactive resource cost types from the service based on the page request
        List<Domain.Abilities.ResourceCostType> resourceCostTypes = await _resourceCostTypeService.GetInActiveList(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        // Map the list of inactive resource cost types to the response objects
        List<GetListByInActiveResourceCostTypeQueryResponse> mappedResponse = _mapper.Map<List<GetListByInActiveResourceCostTypeQueryResponse>>(resourceCostTypes);

        // Return the mapped response
        return mappedResponse;


    }
}

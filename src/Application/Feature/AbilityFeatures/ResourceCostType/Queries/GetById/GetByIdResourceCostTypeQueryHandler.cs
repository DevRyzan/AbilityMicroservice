using Application.Feature.AbilityFeatures.ResourceCostType.Rules;
using Application.Service.AbilityServices.ResourceCostTypeService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.ResourceCostType.Queries.GetById;

public class GetByIdResourceCostTypeQueryHandler : IRequestHandler<GetByIdResourceCostTypeQueryRequest, GetByIdResourceCostTypeQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly IResourceCostTypeService _resourceCostTypeService;
    private readonly ResourceCostTypeBusinessRules _resourceCostTypeBusinessRules;

    public GetByIdResourceCostTypeQueryHandler(IMapper mapper, IResourceCostTypeService resourceCostTypeService, ResourceCostTypeBusinessRules resourceCostTypeBusinessRules)
    {
        _mapper = mapper;
        _resourceCostTypeService = resourceCostTypeService;
        _resourceCostTypeBusinessRules = resourceCostTypeBusinessRules;
    }

    public async Task<GetByIdResourceCostTypeQueryResponse> Handle(GetByIdResourceCostTypeQueryRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the ID provided in the request exists
        await _resourceCostTypeBusinessRules.IdShouldBeExist(request.GetByIdResourcesCostTypeDto.Id);

        // Retrieve the resource cost type from the service by its ID
        Domain.Abilities.ResourceCostType resourceCostType = await _resourceCostTypeService.GetById(request.GetByIdResourcesCostTypeDto.Id);

        // Map the retrieved resource cost type to the response object
        GetByIdResourceCostTypeQueryResponse mappedResponse = _mapper.Map<GetByIdResourceCostTypeQueryResponse>(resourceCostType);

        // Return the mapped response
        return mappedResponse;


    }
}

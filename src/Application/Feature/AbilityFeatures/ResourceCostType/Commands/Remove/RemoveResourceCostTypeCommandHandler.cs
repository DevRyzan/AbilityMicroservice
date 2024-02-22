using Application.Feature.AbilityFeatures.ResourceCostType.Rules;
using Application.Service.AbilityServices.ResourceCostTypeService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.ResourceCostType.Commands.Remove;

public class RemoveResourceCostTypeCommandHandler : IRequestHandler<RemoveResourceCostTypeCommandRequest, RemoveResourceCostTypeCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IResourceCostTypeService _resourceCostTypeService;
    private readonly ResourceCostTypeBusinessRules _resourceCostTypeBusinessRules;

    public RemoveResourceCostTypeCommandHandler(IMapper mapper, IResourceCostTypeService resourceCostTypeService, ResourceCostTypeBusinessRules resourceCostTypeBusinessRules)
    {
        _mapper = mapper;
        _resourceCostTypeService = resourceCostTypeService;
        _resourceCostTypeBusinessRules = resourceCostTypeBusinessRules;
    }

    public async Task<RemoveResourceCostTypeCommandResponse> Handle(RemoveResourceCostTypeCommandRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the ID provided in the request exists
        await _resourceCostTypeBusinessRules.IdShouldBeExist(request.RemoveResourcesCostTypeDto.Id);

        // Execute additional business rules for removing the resource cost type
        await _resourceCostTypeBusinessRules.RemoveCondition(request.RemoveResourcesCostTypeDto.Id);

        // Retrieve the resource cost type from the service by its ID
        Domain.Abilities.ResourceCostType resourceCostType = await _resourceCostTypeService.GetById(request.RemoveResourcesCostTypeDto.Id);

        // Remove the resource cost type from the service
        await _resourceCostTypeService.Remove(resourceCostType);

        // Map the removed resource cost type to the response object
        RemoveResourceCostTypeCommandResponse mappedResponse = _mapper.Map<RemoveResourceCostTypeCommandResponse>(resourceCostType);

        // Return the mapped response
        return mappedResponse;


    }
}

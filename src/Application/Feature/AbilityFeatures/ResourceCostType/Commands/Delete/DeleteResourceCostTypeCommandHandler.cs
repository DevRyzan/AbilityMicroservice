using Application.Feature.AbilityFeatures.ResourceCostType.Rules;
using Application.Service.AbilityServices.ResourceCostTypeService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.ResourceCostType.Commands.Delete;

public class DeleteResourceCostTypeCommandHandler : IRequestHandler<DeleteResourceCostTypeCommandRequest, DeleteResourceCostTypeCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IResourceCostTypeService _resourceCostTypeService;
    private readonly ResourceCostTypeBusinessRules _resourceCostTypeBusinessRules;

    public DeleteResourceCostTypeCommandHandler(IMapper mapper, IResourceCostTypeService resourceCostTypeService, ResourceCostTypeBusinessRules resourceCostTypeBusinessRules)
    {
        _mapper = mapper;
        _resourceCostTypeService = resourceCostTypeService;
        _resourceCostTypeBusinessRules = resourceCostTypeBusinessRules;
    }

    public async Task<DeleteResourceCostTypeCommandResponse> Handle(DeleteResourceCostTypeCommandRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the ID provided in the request exists
        await _resourceCostTypeBusinessRules.IdShouldBeExist(id: request.DeleteResourcesCostTypeDto.Id);

        // Retrieve the resource cost type from the service by its ID
        Domain.Abilities.ResourceCostType resourceCostType = await _resourceCostTypeService.GetById(request.DeleteResourcesCostTypeDto.Id);

        // Mark the resource cost type as deleted
        resourceCostType.IsDeleted = true;

        // Set the deletion date of the resource cost type to the current date and time
        resourceCostType.DeletedDate = DateTime.Now;

        // Delete the resource cost type from the service
        await _resourceCostTypeService.Delete(resourceCostType);

        // Map the deleted resource cost type to the response object
        DeleteResourceCostTypeCommandResponse mappedResponse = _mapper.Map<DeleteResourceCostTypeCommandResponse>(resourceCostType);

        // Return the mapped response
        return mappedResponse;

    }
}

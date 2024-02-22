using Application.Feature.AbilityFeatures.ResourceCostType.Rules;
using Application.Service.AbilityServices.ResourceCostTypeService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.ResourceCostType.Commands.UndoDelete;

public class UndoDeleteResourceCostTypeCommandHandler : IRequestHandler<UndoDeleteResourceCostTypeCommandRequest, UndoDeleteResourceCostTypeCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IResourceCostTypeService _resourceCostTypeService;
    private readonly ResourceCostTypeBusinessRules _resourceCostTypeBusinessRules;

    public UndoDeleteResourceCostTypeCommandHandler(IMapper mapper, IResourceCostTypeService resourceCostTypeService, ResourceCostTypeBusinessRules resourceCostTypeBusinessRules)
    {
        _mapper = mapper;
        _resourceCostTypeService = resourceCostTypeService;
        _resourceCostTypeBusinessRules = resourceCostTypeBusinessRules;
    }

    public async Task<UndoDeleteResourceCostTypeCommandResponse> Handle(UndoDeleteResourceCostTypeCommandRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the ID provided in the request exists
        await _resourceCostTypeBusinessRules.IdShouldBeExist(request.UndoDeleteResourcesCostTypeDto.Id);

        // Retrieve the resource cost type from the service by its ID
        Domain.Abilities.ResourceCostType resourceCostType = await _resourceCostTypeService.GetById(request.UndoDeleteResourcesCostTypeDto.Id);

        // Restore the resource cost type by marking it as not deleted
        resourceCostType.IsDeleted = false;

        // Update the updated date of the resource cost type to the current date and time
        resourceCostType.UpdatedDate = DateTime.Now;

        // Update the resource cost type in the service
        await _resourceCostTypeService.Update(resourceCostType);

        // Map the updated resource cost type to the response object
        UndoDeleteResourceCostTypeCommandResponse mappedResponse = _mapper.Map<UndoDeleteResourceCostTypeCommandResponse>(resourceCostType);

        // Return the mapped response
        return mappedResponse;

    }
}

using Application.Feature.AbilityFeatures.ResourceCostType.Rules;
using Application.Service.AbilityServices.ResourceCostTypeService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.ResourceCostType.Commands.Update;

public class UpdateResourceCostTypeCommandHandler : IRequestHandler<UpdateResourceCostTypeCommandRequest, UpdateResourceCostTypeCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IResourceCostTypeService _resourceCostTypeService;
    private readonly ResourceCostTypeBusinessRules _resourceCostTypeBusinessRules;

    public UpdateResourceCostTypeCommandHandler(IMapper mapper, IResourceCostTypeService resourceCostTypeService, ResourceCostTypeBusinessRules resourceCostTypeBusinessRules)
    {
        _mapper = mapper;
        _resourceCostTypeService = resourceCostTypeService;
        _resourceCostTypeBusinessRules = resourceCostTypeBusinessRules;
    }

    public async Task<UpdateResourceCostTypeCommandResponse> Handle(UpdateResourceCostTypeCommandRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the ID provided in the request exists
        await _resourceCostTypeBusinessRules.IdShouldBeExist(request.UpdateResourcesCostTypeDto.Id);

        // Retrieve the resource cost type from the service by its ID
        Domain.Abilities.ResourceCostType resourceCostType = await _resourceCostTypeService.GetById(request.UpdateResourcesCostTypeDto.Id);

        // Update the name of the resource cost type with the new value from the request
        resourceCostType.Name = request.UpdateResourcesCostTypeDto.Name;

        // Update the updated date of the resource cost type to the current date and time
        resourceCostType.UpdatedDate = DateTime.Now;

        // Update the resource cost type in the service
        await _resourceCostTypeService.Update(resourceCostType);

        // Map the updated resource cost type to the response object
        UpdateResourceCostTypeCommandResponse mappedResponse = _mapper.Map<UpdateResourceCostTypeCommandResponse>(resourceCostType);

        // Return the mapped response
        return mappedResponse;


    }
}

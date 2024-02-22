using Application.Feature.AbilityFeatures.ResourceCostType.Rules;
using Application.Service.AbilityServices.ResourceCostTypeService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.ResourceCostType.Commands.ChangeStatus;

public class ChangeStatusResourceCostTypeCommandHandler : IRequestHandler<ChangeStatusResourceCostTypeCommandRequest, ChangeStatusResourceCostTypeCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IResourceCostTypeService _resourceCostTypeService;
    private readonly ResourceCostTypeBusinessRules _resourceCostTypeBusinessRules;

    public ChangeStatusResourceCostTypeCommandHandler(IMapper mapper, IResourceCostTypeService resourceCostTypeService, ResourceCostTypeBusinessRules resourceCostTypeBusinessRules)
    {
        _mapper = mapper;
        _resourceCostTypeService = resourceCostTypeService;
        _resourceCostTypeBusinessRules = resourceCostTypeBusinessRules;
    }

    public async Task<ChangeStatusResourceCostTypeCommandResponse> Handle(ChangeStatusResourceCostTypeCommandRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the ID provided in the request exists
        await _resourceCostTypeBusinessRules.IdShouldBeExist(request.ChangeStatusResourceCostTypeDto.Id);

        // Retrieve the resource cost type from the service by its ID
        Domain.Abilities.ResourceCostType resourceCostType = await _resourceCostTypeService.GetById(id: request.ChangeStatusResourceCostTypeDto.Id);

        // Toggle the status of the resource cost type
        resourceCostType.Status = resourceCostType.Status == true ? false : true;

        // Update the updated date of the resource cost type
        resourceCostType.UpdatedDate = DateTime.Now;

        // Update the resource cost type in the service
        await _resourceCostTypeService.Update(resourceCostType);

        // Map the updated resource cost type to the response object
        ChangeStatusResourceCostTypeCommandResponse mappedResponse = _mapper.Map<ChangeStatusResourceCostTypeCommandResponse>(resourceCostType);

        // Return the mapped response
        return mappedResponse;

    }
}

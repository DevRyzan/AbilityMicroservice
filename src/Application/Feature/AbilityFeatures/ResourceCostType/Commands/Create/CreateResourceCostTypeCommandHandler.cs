using Application.Feature.AbilityFeatures.ResourceCostType.Rules;
using Application.Service.AbilityServices.ResourceCostTypeService;
using AutoMapper;
using Core.Application.Generator;
using MediatR;
using MongoDB.Bson;

namespace Application.Feature.AbilityFeatures.ResourceCostType.Commands.Create;

public class CreateResourceCostTypeCommandHandler : IRequestHandler<CreateResourceCostTypeCommandRequest, CreateResourceCostTypeCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IResourceCostTypeService _resourceCostTypeService;
    private readonly ResourceCostTypeBusinessRules _resourceCostTypeBusinessRules;

    public CreateResourceCostTypeCommandHandler(IMapper mapper, IResourceCostTypeService resourceCostTypeService, ResourceCostTypeBusinessRules resourceCostTypeBusinessRules)
    {
        _mapper = mapper;
        _resourceCostTypeService = resourceCostTypeService;
        _resourceCostTypeBusinessRules = resourceCostTypeBusinessRules;
    }

    public async Task<CreateResourceCostTypeCommandResponse> Handle(CreateResourceCostTypeCommandRequest request, CancellationToken cancellationToken)
    {
        // Create an instance of the RandomCodeGenerator
        RandomCodeGenerator randomCodeGenerator = new();

        // Map the request data to a new instance of ResourceCostType
        Domain.Abilities.ResourceCostType resourceCostType = _mapper.Map<Domain.Abilities.ResourceCostType>(request.CreateResourcesCostTypeDto);

        // Generate a new unique ID for the resource cost type
        resourceCostType.Id = ObjectId.GenerateNewId().ToString();

        // Set the status of the resource cost type to true
        resourceCostType.Status = true;

        // Set the deletion status of the resource cost type to false
        resourceCostType.IsDeleted = false;

        // Generate a unique code for the resource cost type using the random code generator
        resourceCostType.Code = randomCodeGenerator.GenerateUniqueCode();

        // Set the creation date of the resource cost type to the current date and time
        resourceCostType.CreatedDate = DateTime.Now;

        // Create the resource cost type in the service
        await _resourceCostTypeService.Create(resourceCostType);

        // Map the created resource cost type to the response object
        CreateResourceCostTypeCommandResponse mappedResponse = _mapper.Map<CreateResourceCostTypeCommandResponse>(resourceCostType);

        // Return the mapped response
        return mappedResponse;

    }
}

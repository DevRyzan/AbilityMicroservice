using Application.Feature.AbilityFeatures.AbilityTypes.Rules;
using Application.Service.AbilityServices.AbilityTypeService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Abilities;
using MediatR;
using MongoDB.Bson;


namespace Application.Feature.AbilityFeatures.AbilityTypes.Commands.Create;

public class CreateAbilityTypeCommandHandler : IRequestHandler<CreateAbilityTypeCommandRequest, CreateAbilityTypeCommandResponse>
{
    private readonly IAbilityTypeService _abilityTypeService;
    private readonly AbilityTypeBusinessRules _abilityTypeBusinessRules;
    private readonly IMapper _mapper;

    public CreateAbilityTypeCommandHandler(IAbilityTypeService abilityTypeService, AbilityTypeBusinessRules abilityTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityTypeBusinessRules = abilityTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateAbilityTypeCommandResponse> Handle(CreateAbilityTypeCommandRequest request, CancellationToken cancellationToken)
    {
        // Create a new instance of the RandomCodeGenerator for generating unique codes
        RandomCodeGenerator randomCodeGenerator = new();

        // Map data from the incoming request DTO to a new AbilityType object
        AbilityType abilityType = _mapper.Map<AbilityType>(request.CreateAbilityTypeDto);

        // Generate a new unique identifier for the AbilityType
        abilityType.Id = ObjectId.GenerateNewId().ToString();

        // Set default values for the new AbilityType
        abilityType.Status = true;          // Assuming 'Status' is a boolean property
        abilityType.IsDeleted = false;      // Assuming 'IsDeleted' is a boolean property
        abilityType.Code = randomCodeGenerator.GenerateUniqueCode();
        abilityType.CreatedDate = DateTime.Now;  // Set the creation date to the current date and time

        // Create the new AbilityType by calling the _abilityTypeService
        await _abilityTypeService.Create(abilityType);

        // Map the created AbilityType to the response DTO
        CreateAbilityTypeCommandResponse mappedResponse = _mapper.Map<CreateAbilityTypeCommandResponse>(abilityType);

        // Return the mapped response to the calling code
        return mappedResponse;

    }
}

using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Service.AbilityServices.AbilityActivationTypeService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Abilities;
using MediatR;
using MongoDB.Bson;


namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Create;

public class CreateAbilityActivationTypeHandler : IRequestHandler<CreateAbilityActivationTypeRequest, CreateAbilityActivationTypeResponse>
{
    private readonly IAbilityActivationTypeService _abilityActivationTypeService;
    private readonly AbilityActivationTypeBusinessRules _abilityActivationTypeBusinessRules;
    private readonly IMapper _mapper;

    public CreateAbilityActivationTypeHandler(IAbilityActivationTypeService abilityActivationTypeService, AbilityActivationTypeBusinessRules abilityActivationTypeBusinessRules, IMapper mapper)
    {
        _abilityActivationTypeService = abilityActivationTypeService;
        _abilityActivationTypeBusinessRules = abilityActivationTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateAbilityActivationTypeResponse> Handle(CreateAbilityActivationTypeRequest request, CancellationToken cancellationToken)
    {// Create a new instance of the RandomCodeGenerator.
        RandomCodeGenerator randomCodeGenerator = new();

        // Map the data from the request DTO to an AbilityActivationType object.
        AbilityActivationType abilityActivationType = _mapper.Map<AbilityActivationType>(request.CreateAbilityActivationTypeDto);

        // Generate a new unique identifier (ID) for the AbilityActivationType.
        abilityActivationType.Id = ObjectId.GenerateNewId().ToString();

        // Set initial values for status, deletion status, and code.
        abilityActivationType.Status = true;
        abilityActivationType.IsDeleted = false;
        abilityActivationType.Code = randomCodeGenerator.GenerateUniqueCode();

        // Set the creation timestamp for the AbilityActivationType.
        abilityActivationType.CreatedDate = DateTime.Now;

        // Create the AbilityActivationType in the database using the service.
        await _abilityActivationTypeService.Create(abilityActivationType);

        // Map the created AbilityActivationType to the response DTO.
        CreateAbilityActivationTypeResponse mappedResponse = _mapper.Map<CreateAbilityActivationTypeResponse>(abilityActivationType);

        // Return the mapped response.
        return mappedResponse;

    }
}

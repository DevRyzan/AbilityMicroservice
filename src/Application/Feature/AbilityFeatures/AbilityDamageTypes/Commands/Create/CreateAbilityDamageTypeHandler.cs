using Application.Feature.AbilityFeatures.AbilityDamageTypes.Rules;
using Application.Service.AbilityServices.AbilityDamageTypeService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Abilities;
using MediatR;
using MongoDB.Bson;


namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Create;

public class CreateAbilityDamageTypeHandler : IRequestHandler<CreateAbilityDamageTypeRequest, CreateAbilityDamageTypeResponse>
{

    private readonly IAbilityDamageTypeService _abilityDamageTypeService;
    private readonly AbilityDamageTypeBusinessRules _abilityDamageTypeBusinessRules;
    private readonly IMapper _mapper;

    public CreateAbilityDamageTypeHandler(IAbilityDamageTypeService abilityDamageTypeService, AbilityDamageTypeBusinessRules abilityDamageTypeBusinessRules, IMapper mapper)
    {
        _abilityDamageTypeService = abilityDamageTypeService;
        _abilityDamageTypeBusinessRules = abilityDamageTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateAbilityDamageTypeResponse> Handle(CreateAbilityDamageTypeRequest request, CancellationToken cancellationToken)
    {
        // Create a new instance of the RandomCodeGenerator.
        RandomCodeGenerator randomCodeGenerator = new RandomCodeGenerator();

        // Map the data from the request DTO to an AbilityDamageType object.
        AbilityDamageType abilityDamageType = _mapper.Map<AbilityDamageType>(request.CreateAbilityDamageTypeDto);

        // Generate a new unique identifier (ID) for the AbilityDamageType.
        abilityDamageType.Id = ObjectId.GenerateNewId().ToString();

        // Set initial values for status, deletion status, and creation timestamp.
        abilityDamageType.Status = true;
        abilityDamageType.IsDeleted = false;

        // Generate a new unique code for the AbilityDamageType.
        abilityDamageType.Code = randomCodeGenerator.GenerateUniqueCode();

        // Set the creation timestamp for the AbilityDamageType.
        abilityDamageType.CreatedDate = DateTime.Now;

        // Create the AbilityDamageType in the database using the service.
        await _abilityDamageTypeService.Create(abilityDamageType);

        // Map the created AbilityDamageType to the response DTO.
        CreateAbilityDamageTypeResponse mappedResponse = _mapper.Map<CreateAbilityDamageTypeResponse>(abilityDamageType);

        // Return the mapped response.
        return mappedResponse;

    }
}

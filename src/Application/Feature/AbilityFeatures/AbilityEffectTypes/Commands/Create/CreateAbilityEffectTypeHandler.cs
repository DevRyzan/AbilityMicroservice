using Application.Feature.AbilityFeatures.AbilityEffectTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectTypeService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Abilities;
using MediatR;
using MongoDB.Bson;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Create;

public class CreateAbilityEffectTypeHandler : IRequestHandler<CreateAbilityEffectTypeRequest, CreateAbilityEffectTypeResponse>
{
    private readonly IAbilityEffectTypeService _abilityTypeService;
    private readonly AbilityEffectTypeBusinessRules _abilityEffectTypeBusinessRules;
    private readonly IMapper _mapper;

    public CreateAbilityEffectTypeHandler(IAbilityEffectTypeService abilityTypeService, AbilityEffectTypeBusinessRules abilityEffectTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityEffectTypeBusinessRules = abilityEffectTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateAbilityEffectTypeResponse> Handle(CreateAbilityEffectTypeRequest request, CancellationToken cancellationToken)
    {
        // Create an instance of RandomCodeGenerator for generating unique codes
        RandomCodeGenerator randomCodeGenerator = new();

        // Map the DTO to the entity (AbilityEffectType) using AutoMapper
        AbilityEffectType abilityEffectType = _mapper.Map<AbilityEffectType>(request.CreateAbilityEffectTypeDto);

        // Generate a new unique ID for the AbilityEffectType
        abilityEffectType.Id = ObjectId.GenerateNewId().ToString();

        // Set default values for the new AbilityEffectType
        abilityEffectType.Status = true;            // Set status to true
        abilityEffectType.IsDeleted = false;        // Set IsDeleted to false
        abilityEffectType.Code = randomCodeGenerator.GenerateUniqueCode(); // Generate a unique code
        abilityEffectType.CreatedDate = DateTime.Now;  // Set CreatedDate to the current timestamp

        // Use the service to create the new AbilityEffectType in the database
        await _abilityTypeService.Create(abilityEffectType);

        // Map the created AbilityEffectType to the response DTO
        CreateAbilityEffectTypeResponse mappedResponse = _mapper.Map<CreateAbilityEffectTypeResponse>(abilityEffectType);

        // Return the mapped response
        return mappedResponse;

    }
}

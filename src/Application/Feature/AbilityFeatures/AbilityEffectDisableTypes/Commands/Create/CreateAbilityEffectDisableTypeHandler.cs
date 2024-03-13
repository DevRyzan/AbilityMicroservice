using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectDisableTypeService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Abilities;
using MediatR;
using MongoDB.Bson;

namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Create;

public class CreateAbilityEffectDisableTypeHandler : IRequestHandler<CreateAbilityEffectDisableTypeRequest, CreateAbilityEffectDisableTypeResponse>
{
    private readonly IAbilityEffectDisableTypeService _abilityEffectDisableTypeService;
    private readonly AbilityEffectDisableTypeBusinessRules _abilityEffectDisableTypeBusinessRules;
    private readonly IMapper _mapper;

    public CreateAbilityEffectDisableTypeHandler(IAbilityEffectDisableTypeService abilityEffectDisableTypeService, AbilityEffectDisableTypeBusinessRules abilityEffectDisableTypeBusinessRules, IMapper mapper)
    {
        _abilityEffectDisableTypeService = abilityEffectDisableTypeService;
        _abilityEffectDisableTypeBusinessRules = abilityEffectDisableTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateAbilityEffectDisableTypeResponse> Handle(CreateAbilityEffectDisableTypeRequest request, CancellationToken cancellationToken)
    {
        // Create a new instance of the RandomCodeGenerator.
        RandomCodeGenerator randomCodeGenerator = new RandomCodeGenerator();

        // Map the data from the request DTO to a new AbilityEffectDisableType instance.
        AbilityEffectDisableType abilityEffectDisableType = _mapper.Map<AbilityEffectDisableType>(request.CreateAbilityEffectDisableTypeDto);

        // Generate a new ID for the AbilityEffectDisableType.
        abilityEffectDisableType.Id = ObjectId.GenerateNewId().ToString();

        // Set initial values for the Status, IsDeleted, and Code properties.
        abilityEffectDisableType.Status = true;
        abilityEffectDisableType.IsDeleted = false;
        abilityEffectDisableType.Code = randomCodeGenerator.GenerateUniqueCode();
        abilityEffectDisableType.CreatedDate = DateTime.Now;

        // Create the AbilityEffectDisableType in the database using the service.
        await _abilityEffectDisableTypeService.Create(abilityEffectDisableType);

        // Map the created AbilityEffectDisableType to the response DTO.
        CreateAbilityEffectDisableTypeResponse mappedResponse = _mapper.Map<CreateAbilityEffectDisableTypeResponse>(abilityEffectDisableType);

        // Return the mapped response.
        return mappedResponse;


    }
}

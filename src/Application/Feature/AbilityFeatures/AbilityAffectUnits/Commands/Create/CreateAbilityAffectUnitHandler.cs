using Application.Feature.AbilityFeatures.AbilityAffectUnits.Rules;
using Application.Service.AbilityServices.AbilityAffectUnitService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Abilities;
using MediatR;
using MongoDB.Bson;


namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Create;

public class CreateAbilityAffectUnitHandler : IRequestHandler<CreateAbilityAffectUnitRequest, CreateAbilityAffectUnitResponse>
{
    private readonly IAbilityAffectUnitService _abilityAffectUnitService;
    private readonly AbilityAffectUnitBusinessRules _abilityAffectUnitBusinessRules;
    private readonly IMapper _mapper;

    public CreateAbilityAffectUnitHandler(IAbilityAffectUnitService abilityAffectUnitService, AbilityAffectUnitBusinessRules abilityAffectUnitBusinessRules, IMapper mapper)
    {
        _abilityAffectUnitService = abilityAffectUnitService;
        _abilityAffectUnitBusinessRules = abilityAffectUnitBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateAbilityAffectUnitResponse> Handle(CreateAbilityAffectUnitRequest request, CancellationToken cancellationToken)
    {
        // Create a new instance of the RandomCodeGenerator.
        RandomCodeGenerator randomCodeGenerator = new();

        // Map the data from the request DTO to an AbilityAffectUnit object.
        AbilityAffectUnit abilityAffectUnit = _mapper.Map<AbilityAffectUnit>(request.CreateAbilityAffectUnitDto);

        // Generate a new unique identifier (ID) for the AbilityAffectUnit.
        abilityAffectUnit.Id = ObjectId.GenerateNewId().ToString();

        // Set initial values for status, deletion status, and code.
        abilityAffectUnit.Status = true;
        abilityAffectUnit.IsDeleted = false;
        abilityAffectUnit.Code = randomCodeGenerator.GenerateUniqueCode();

        // Set the creation timestamp for the AbilityAffectUnit.
        abilityAffectUnit.CreatedDate = DateTime.Now;

        // Create the AbilityAffectUnit in the database using the service.
        await _abilityAffectUnitService.Create(abilityAffectUnit);

        // Map the created AbilityAffectUnit to the response DTO.
        CreateAbilityAffectUnitResponse mappedResponse = _mapper.Map<CreateAbilityAffectUnitResponse>(abilityAffectUnit);

        // Return the mapped response.
        return mappedResponse;

    }
}

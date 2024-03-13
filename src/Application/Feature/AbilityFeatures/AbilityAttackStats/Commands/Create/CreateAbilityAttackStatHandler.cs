using Application.Feature.AbilityFeatures.AbilityAttackStats.Rules;
using Application.Service.AbilityServices.AbilityAttackStatService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Abilities;
using MediatR;
using MongoDB.Bson;


namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Create;

public class CreateAbilityAttackStatHandler : IRequestHandler<CreateAbilityAttackStatRequest, CreateAbilityAttackStatResponse>
{
    private readonly IAbilityAttackStatService _abilityAttackStatService;
    private readonly AbilityAttackStatBusinessRules _abilityAttackStatBusinessRules;
    private readonly IMapper _mapper;

    public CreateAbilityAttackStatHandler(IAbilityAttackStatService abilityAttackStatService, AbilityAttackStatBusinessRules abilityAttackStatBusinessRules, IMapper mapper)
    {
        _abilityAttackStatService = abilityAttackStatService;
        _abilityAttackStatBusinessRules = abilityAttackStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateAbilityAttackStatResponse> Handle(CreateAbilityAttackStatRequest request, CancellationToken cancellationToken)
    {
        // Create a new instance of the RandomCodeGenerator.
        RandomCodeGenerator codeGenerator = new RandomCodeGenerator();

        // Map the data from the request DTO to an AbilityAttackStat object.
        AbilityAttackStat abilityAttackStat = _mapper.Map<AbilityAttackStat>(request.CreateAbilityAttackStatDto);

        // Generate a new unique identifier (ID) for the AbilityAttackStat.
        abilityAttackStat.Id = ObjectId.GenerateNewId().ToString();

        // Generate a new unique code for the AbilityAttackStat.
        abilityAttackStat.Code = codeGenerator.GenerateUniqueCode();

        // Set initial values for status, deletion status, and creation timestamp.
        abilityAttackStat.Status = true;
        abilityAttackStat.IsDeleted = false;
        abilityAttackStat.CreatedDate = DateTime.Now;

        // Create the AbilityAttackStat in the database using the service.
        await _abilityAttackStatService.Create(abilityAttackStat);

        // Map the created AbilityAttackStat to the response DTO.
        CreateAbilityAttackStatResponse mappedResponse = _mapper.Map<CreateAbilityAttackStatResponse>(abilityAttackStat);

        // Return the mapped response.
        return mappedResponse;

    }
}

using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEnemyEffectStatService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Abilities;
using MediatR;
using MongoDB.Bson;

namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.Create;

public class CreateAbilityEnemyEffectStatHandler : IRequestHandler<CreateAbilityEnemyEffectStatRequest, CreateAbilityEnemyEffectStatResponse>
{
    private readonly IAbilityEnemyEffectStatService _abilityEnemyEffectStatService;
    private readonly AbilityEnemyEffectStatBusinessRules _abilityEnemyEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public CreateAbilityEnemyEffectStatHandler(IAbilityEnemyEffectStatService abilityEnemyEffectStatService, AbilityEnemyEffectStatBusinessRules abilityEnemyEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEnemyEffectStatService = abilityEnemyEffectStatService;
        _abilityEnemyEffectStatBusinessRules = abilityEnemyEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateAbilityEnemyEffectStatResponse> Handle(CreateAbilityEnemyEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Create a new instance of RandomCodeGenerator for generating unique codes
        RandomCodeGenerator randomCodeGenerator = new();

        // Map the data from the request DTO to a new instance of AbilityEnemyEffectStat
        AbilityEnemyEffectStat abilityEnemyEffectStat = _mapper.Map<AbilityEnemyEffectStat>(request.CreateAbilityEnemyEffectStatDto);

        // Generate a new unique ID for the AbilityEnemyEffectStat using ObjectId
        abilityEnemyEffectStat.Id = ObjectId.GenerateNewId().ToString();

        // Set the initial Status to true
        abilityEnemyEffectStat.Status = true;

        // Set IsDeleted to false since it's a new record
        abilityEnemyEffectStat.IsDeleted = false;

        // Generate a unique code for the AbilityEnemyEffectStat using the random code generator
        abilityEnemyEffectStat.Code = randomCodeGenerator.GenerateUniqueCode();

        // Set the CreatedDate to the current date and time
        abilityEnemyEffectStat.CreatedDate = DateTime.Now;

        // Call the service to create the new AbilityEnemyEffectStat
        await _abilityEnemyEffectStatService.Create(abilityEnemyEffectStat);

        // Map the created AbilityEnemyEffectStat to the response DTO
        CreateAbilityEnemyEffectStatResponse mappedResponse = _mapper.Map<CreateAbilityEnemyEffectStatResponse>(abilityEnemyEffectStat);

        // Return the mapped response
        return mappedResponse;

    }
}

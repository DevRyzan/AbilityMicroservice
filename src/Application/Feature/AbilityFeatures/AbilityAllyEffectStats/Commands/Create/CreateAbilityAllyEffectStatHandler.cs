using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityAllyEffectStatService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Abilities;
using MediatR;
using MongoDB.Bson;


namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.Create;

public class CreateAbilityAllyEffectStatHandler : IRequestHandler<CreateAbilityAllyEffectStatRequest, CreateAbilityAllyEffectStatResponse>
{
    private readonly IAbilityAllyEffectStatService _abilityAllyEffectStatService;
    private readonly AbilityAllyEffectStatsBusinessRules _abilityAllyEffectStatsBusinessRules;
    private readonly IMapper _mapper;

    public CreateAbilityAllyEffectStatHandler(IAbilityAllyEffectStatService abilityAllyEffectStatService, AbilityAllyEffectStatsBusinessRules abilityAllyEffectStatsBusinessRules, IMapper mapper)
    {
        _abilityAllyEffectStatService = abilityAllyEffectStatService;
        _abilityAllyEffectStatsBusinessRules = abilityAllyEffectStatsBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateAbilityAllyEffectStatResponse> Handle(CreateAbilityAllyEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Create a new instance of the RandomCodeGenerator.
        RandomCodeGenerator codeGenerator = new RandomCodeGenerator();

        // Map the data from the request DTO to an AbilityAllyEffectStat object.
        AbilityAllyEffectStat abilityAllyEffectStat = _mapper.Map<AbilityAllyEffectStat>(request.CreateAbilityAllyEffectStatDto);

        // Generate a new unique identifier (ID) for the AbilityAllyEffectStat.
        abilityAllyEffectStat.Id = ObjectId.GenerateNewId().ToString();

        // Set initial values for status, deletion status, and code.
        abilityAllyEffectStat.Status = true;
        abilityAllyEffectStat.IsDeleted = false;
        abilityAllyEffectStat.Code = codeGenerator.GenerateUniqueCode();

        // Set the creation timestamp for the AbilityAllyEffectStat.
        abilityAllyEffectStat.CreatedDate = DateTime.Now;

        // Create the AbilityAllyEffectStat in the database using the service.
        await _abilityAllyEffectStatService.Create(abilityAllyEffectStat);

        // Map the created AbilityAllyEffectStat to the response DTO.
        CreateAbilityAllyEffectStatResponse mappedResponse = _mapper.Map<CreateAbilityAllyEffectStatResponse>(abilityAllyEffectStat);

        // Return the mapped response.
        return mappedResponse;

    }
}

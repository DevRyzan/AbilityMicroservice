using Application.Feature.AbilityFeatures.AbilityEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEffectStatService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Abilities;
using MediatR;
using MongoDB.Bson;


namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.Create;

public class CreateAbilityEffectStatHandler : IRequestHandler<CreateAbilityEffectStatRequest, CreateAbilityEffectStatResponse>
{
    private readonly IAbilityEffectStatService _abilityEffectStatService;
    private readonly AbilityEffectStatBusinessRules _abilityEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public CreateAbilityEffectStatHandler(IAbilityEffectStatService abilityEffectStatService, AbilityEffectStatBusinessRules abilityEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEffectStatService = abilityEffectStatService;
        _abilityEffectStatBusinessRules = abilityEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateAbilityEffectStatResponse> Handle(CreateAbilityEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Create an instance of the RandomCodeGenerator.
        RandomCodeGenerator randomCodeGenerator = new RandomCodeGenerator();

        // Map the DTO to the entity.
        AbilityEffectStat abilityEffectStat = _mapper.Map<AbilityEffectStat>(request.CreateAbilityEffectStatDto);

        // Generate a new ID, set default values, and assign a unique code.
        abilityEffectStat.Id = ObjectId.GenerateNewId().ToString();
        abilityEffectStat.Status = true;
        abilityEffectStat.IsDeleted = false;
        abilityEffectStat.Code = randomCodeGenerator.GenerateUniqueCode();
        abilityEffectStat.CreatedDate = DateTime.Now;

        // Create the AbilityEffectStat entity in the database.
        await _abilityEffectStatService.Create(abilityEffectStat);

        // Map the created AbilityEffectStat entity to the response DTO.
        CreateAbilityEffectStatResponse mappedResponse = _mapper.Map<CreateAbilityEffectStatResponse>(abilityEffectStat);

        // Return the mapped response.
        return mappedResponse;

    }
}

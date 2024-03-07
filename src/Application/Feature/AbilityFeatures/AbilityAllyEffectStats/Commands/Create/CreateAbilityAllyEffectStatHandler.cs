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
        RandomCodeGenerator codeGenerator = new RandomCodeGenerator();

        AbilityAllyEffectStat abilityAllyEffectStat = _mapper.Map<AbilityAllyEffectStat>(request.CreateAbilityAllyEffectStatDto);
        abilityAllyEffectStat.Id = ObjectId.GenerateNewId().ToString();
        abilityAllyEffectStat.Status = true;
        abilityAllyEffectStat.IsDeleted = false;
        abilityAllyEffectStat.Code = codeGenerator.GenerateUniqueCode();
        abilityAllyEffectStat.CreatedDate = DateTime.Now;

        await _abilityAllyEffectStatService.Create(abilityAllyEffectStat);

        CreateAbilityAllyEffectStatResponse mappedResponse = _mapper.Map<CreateAbilityAllyEffectStatResponse>(abilityAllyEffectStat);
        return mappedResponse;
    }
}

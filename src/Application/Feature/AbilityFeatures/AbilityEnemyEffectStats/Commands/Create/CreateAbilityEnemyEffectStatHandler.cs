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
        RandomCodeGenerator randomCodeGenerator = new();

        AbilityEnemyEffectStat abilityEnemyEffectStat = _mapper.Map<AbilityEnemyEffectStat>(request.CreateAbilityEnemyEffectStatDto);
        abilityEnemyEffectStat.Id = ObjectId.GenerateNewId().ToString();
        abilityEnemyEffectStat.Status = true;
        abilityEnemyEffectStat.IsDeleted = false;
        abilityEnemyEffectStat.Code = randomCodeGenerator.GenerateUniqueCode();
        abilityEnemyEffectStat.CreatedDate = DateTime.Now;

        await _abilityEnemyEffectStatService.Create(abilityEnemyEffectStat);

        CreateAbilityEnemyEffectStatResponse mappedResponse = _mapper.Map<CreateAbilityEnemyEffectStatResponse>(abilityEnemyEffectStat);
        return mappedResponse;
    }
}

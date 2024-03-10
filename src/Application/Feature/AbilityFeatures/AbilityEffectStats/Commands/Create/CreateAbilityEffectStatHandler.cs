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
        RandomCodeGenerator randomCodeGenerator = new();

        AbilityEffectStat abilityEffectStat = _mapper.Map<AbilityEffectStat>(request.CreateAbilityEffectStatDto);

        abilityEffectStat.Id = ObjectId.GenerateNewId().ToString();
        abilityEffectStat.Status = true;
        abilityEffectStat.IsDeleted = false;
        abilityEffectStat.Code = randomCodeGenerator.GenerateUniqueCode();
        abilityEffectStat.CreatedDate = DateTime.Now;

        await _abilityEffectStatService.Create(abilityEffectStat);

        CreateAbilityEffectStatResponse mappedResponse = _mapper.Map<CreateAbilityEffectStatResponse>(abilityEffectStat);
        return mappedResponse;

    }
}

using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Rules;
using Application.Service.AbilityServices.AbilitySelfEffectStatService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Abilities;
using MediatR;
using MongoDB.Bson;


namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.Create;

public class CreateAbilitySelfEffectStatHandler : IRequestHandler<CreateAbilitySelfEffectStatRequest, CreateAbilitySelfEffectStatResponse>
{
    private readonly IAbilitySelfEffectStatService _abilitySelfEffectStatService;
    private readonly AbilitySelfEffectStatBusinessRules _abilitySelfEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public CreateAbilitySelfEffectStatHandler(IAbilitySelfEffectStatService abilitySelfEffectStatService, AbilitySelfEffectStatBusinessRules abilitySelfEffectStatBusinessRules, IMapper mapper)
    {
        _abilitySelfEffectStatService = abilitySelfEffectStatService;
        _abilitySelfEffectStatBusinessRules = abilitySelfEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateAbilitySelfEffectStatResponse> Handle(CreateAbilitySelfEffectStatRequest request, CancellationToken cancellationToken)
    {
        RandomCodeGenerator randomCodeGenerator = new();

        AbilitySelfEffectStat abilitySelfEffectStat = _mapper.Map<AbilitySelfEffectStat>(request.CreateAbilitySelfEffectStatDto);

        abilitySelfEffectStat.Id = ObjectId.GenerateNewId().ToString();
        abilitySelfEffectStat.Status = true;
        abilitySelfEffectStat.IsDeleted = false;
        abilitySelfEffectStat.Code = randomCodeGenerator.GenerateUniqueCode();
        abilitySelfEffectStat.CreatedDate = DateTime.Now;

        await _abilitySelfEffectStatService.Create(abilitySelfEffectStat);

        CreateAbilitySelfEffectStatResponse mappedResponse = _mapper.Map<CreateAbilitySelfEffectStatResponse>(abilitySelfEffectStat);
        return mappedResponse;

    }
}

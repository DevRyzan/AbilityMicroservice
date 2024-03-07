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
        RandomCodeGenerator codeGenerator = new RandomCodeGenerator();

        AbilityAttackStat abilityAttackStat = _mapper.Map<AbilityAttackStat>(request.CreateAbilityAttackStatDto);
        abilityAttackStat.Id = ObjectId.GenerateNewId().ToString();
        abilityAttackStat.Code = codeGenerator.GenerateUniqueCode();
        abilityAttackStat.Status = true;
        abilityAttackStat.IsDeleted = false;
        abilityAttackStat.CreatedDate = DateTime.Now;

        await _abilityAttackStatService.Create(abilityAttackStat);

        CreateAbilityAttackStatResponse mappedResponse = _mapper.Map<CreateAbilityAttackStatResponse>(abilityAttackStat);
        return mappedResponse;
    }
}

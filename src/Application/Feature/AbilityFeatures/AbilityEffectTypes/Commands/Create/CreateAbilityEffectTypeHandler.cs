using Application.Feature.AbilityFeatures.AbilityEffectTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectTypeService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Abilities;
using MediatR;
using MongoDB.Bson;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Create;

public class CreateAbilityEffectTypeHandler : IRequestHandler<CreateAbilityEffectTypeRequest, CreateAbilityEffectTypeResponse>
{
    private readonly IAbilityEffectTypeService _abilityTypeService;
    private readonly AbilityEffectTypeBusinessRules _abilityEffectTypeBusinessRules;
    private readonly IMapper _mapper;

    public CreateAbilityEffectTypeHandler(IAbilityEffectTypeService abilityTypeService, AbilityEffectTypeBusinessRules abilityEffectTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityEffectTypeBusinessRules = abilityEffectTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateAbilityEffectTypeResponse> Handle(CreateAbilityEffectTypeRequest request, CancellationToken cancellationToken)
    {
        RandomCodeGenerator randomCodeGenerator = new();

        AbilityEffectType abilityEffectType = _mapper.Map<AbilityEffectType>(request.CreateAbilityEffectTypeDto);
        abilityEffectType.Id = ObjectId.GenerateNewId().ToString();
        abilityEffectType.Status = true;
        abilityEffectType.IsDeleted = false;
        abilityEffectType.Code = randomCodeGenerator.GenerateUniqueCode();
        abilityEffectType.CreatedDate = DateTime.Now;

        await _abilityTypeService.Create(abilityEffectType);

        CreateAbilityEffectTypeResponse mappedResponse = _mapper.Map<CreateAbilityEffectTypeResponse>(abilityEffectType);
        return mappedResponse;
    }
}

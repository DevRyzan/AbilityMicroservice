using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectDisableTypeService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Abilities;
using MediatR;
using MongoDB.Bson;



namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Create;

public class CreateAbilityEffectDisableTypeHandler : IRequestHandler<CreateAbilityEffectDisableTypeRequest, CreateAbilityEffectDisableTypeResponse>
{
    private readonly IAbilityEffectDisableTypeService _abilityEffectDisableTypeService;
    private readonly AbilityEffectDisableTypeBusinessRules _abilityEffectDisableTypeBusinessRules;
    private readonly IMapper _mapper;

    public CreateAbilityEffectDisableTypeHandler(IAbilityEffectDisableTypeService abilityEffectDisableTypeService, AbilityEffectDisableTypeBusinessRules abilityEffectDisableTypeBusinessRules, IMapper mapper)
    {
        _abilityEffectDisableTypeService = abilityEffectDisableTypeService;
        _abilityEffectDisableTypeBusinessRules = abilityEffectDisableTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateAbilityEffectDisableTypeResponse> Handle(CreateAbilityEffectDisableTypeRequest request, CancellationToken cancellationToken)
    {
        RandomCodeGenerator randomCodeGenerator = new();

        AbilityEffectDisableType abilityEffectDisableType = _mapper.Map<AbilityEffectDisableType>(request.CreateAbilityEffectDisableTypeDto);
        abilityEffectDisableType.Id = ObjectId.GenerateNewId().ToString();
        abilityEffectDisableType.Status = true;
        abilityEffectDisableType.IsDeleted = false;
        abilityEffectDisableType.Code = randomCodeGenerator.GenerateUniqueCode();
        abilityEffectDisableType.CreatedDate = DateTime.Now;

        await _abilityEffectDisableTypeService.Create(abilityEffectDisableType);

        CreateAbilityEffectDisableTypeResponse mappedResponse = _mapper.Map<CreateAbilityEffectDisableTypeResponse>(abilityEffectDisableType);
        return mappedResponse;

    }
}

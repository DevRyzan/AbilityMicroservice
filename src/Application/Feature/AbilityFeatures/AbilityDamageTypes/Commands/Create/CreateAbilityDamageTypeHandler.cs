using Application.Feature.AbilityFeatures.AbilityDamageTypes.Rules;
using Application.Service.AbilityServices.AbilityDamageTypeService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Abilities;
using MediatR;
using MongoDB.Bson;


namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Create;

public class CreateAbilityDamageTypeHandler : IRequestHandler<CreateAbilityDamageTypeRequest, CreateAbilityDamageTypeResponse>
{

    private readonly IAbilityDamageTypeService _abilityDamageTypeService;
    private readonly AbilityDamageTypeBusinessRules _abilityDamageTypeBusinessRules;
    private readonly IMapper _mapper;

    public CreateAbilityDamageTypeHandler(IAbilityDamageTypeService abilityDamageTypeService, AbilityDamageTypeBusinessRules abilityDamageTypeBusinessRules, IMapper mapper)
    {
        _abilityDamageTypeService = abilityDamageTypeService;
        _abilityDamageTypeBusinessRules = abilityDamageTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateAbilityDamageTypeResponse> Handle(CreateAbilityDamageTypeRequest request, CancellationToken cancellationToken)
    {
        RandomCodeGenerator randomCodeGenerator = new();

        AbilityDamageType abilityDamageType = _mapper.Map<AbilityDamageType>(request.CreateAbilityDamageTypeDto);
        abilityDamageType.Id = ObjectId.GenerateNewId().ToString();
        abilityDamageType.Status = true;
        abilityDamageType.IsDeleted = false;
        abilityDamageType.Code = randomCodeGenerator.GenerateUniqueCode();
        abilityDamageType.CreatedDate = DateTime.Now;

        await _abilityDamageTypeService.Create(abilityDamageType);

        CreateAbilityDamageTypeResponse mappedResponse = _mapper.Map<CreateAbilityDamageTypeResponse>(abilityDamageType);
        return mappedResponse;
    }
}

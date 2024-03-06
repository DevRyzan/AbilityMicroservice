using Application.Feature.AbilityFeatures.AbilityAffectUnits.Rules;
using Application.Service.AbilityServices.AbilityAffectUnitService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Abilities;
using MediatR;
using MongoDB.Bson;


namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Create;

public class CreateAbilityAffectUnitHandler : IRequestHandler<CreateAbilityAffectUnitRequest, CreateAbilityAffectUnitResponse>
{
    private readonly IAbilityAffectUnitService _abilityAffectUnitService;
    private readonly AbilityAffectUnitBusinessRules _abilityAffectUnitBusinessRules;
    private readonly IMapper _mapper;

    public CreateAbilityAffectUnitHandler(IAbilityAffectUnitService abilityAffectUnitService, AbilityAffectUnitBusinessRules abilityAffectUnitBusinessRules, IMapper mapper)
    {
        _abilityAffectUnitService = abilityAffectUnitService;
        _abilityAffectUnitBusinessRules = abilityAffectUnitBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateAbilityAffectUnitResponse> Handle(CreateAbilityAffectUnitRequest request, CancellationToken cancellationToken)
    {
        RandomCodeGenerator randomCodeGenerator = new();

        AbilityAffectUnit abilityAffectUnit = _mapper.Map<AbilityAffectUnit>(request.CreateAbilityAffectUnitDto);
        abilityAffectUnit.Id = ObjectId.GenerateNewId().ToString();
        abilityAffectUnit.Status = true;
        abilityAffectUnit.IsDeleted = false;
        abilityAffectUnit.Code = randomCodeGenerator.GenerateUniqueCode();
        abilityAffectUnit.CreatedDate = DateTime.Now;

        await _abilityAffectUnitService.Create(abilityAffectUnit);

        CreateAbilityAffectUnitResponse mappedResponse = _mapper.Map<CreateAbilityAffectUnitResponse>(abilityAffectUnit);
        return mappedResponse;
    }
}

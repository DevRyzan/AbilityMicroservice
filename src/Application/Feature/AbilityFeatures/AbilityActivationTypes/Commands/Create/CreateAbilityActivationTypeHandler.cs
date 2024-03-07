using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Service.AbilityServices.AbilityActivationTypeService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Abilities;
using MediatR;
using MongoDB.Bson;


namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Create;

public class CreateAbilityActivationTypeHandler : IRequestHandler<CreateAbilityActivationTypeRequest, CreateAbilityActivationTypeResponse>
{
    private readonly IAbilityActivationTypeService _abilityActivationTypeService;
    private readonly AbilityActivationTypeBusinessRules _abilityActivationTypeBusinessRules;
    private readonly IMapper _mapper;

    public CreateAbilityActivationTypeHandler(IAbilityActivationTypeService abilityActivationTypeService, AbilityActivationTypeBusinessRules abilityActivationTypeBusinessRules, IMapper mapper)
    {
        _abilityActivationTypeService = abilityActivationTypeService;
        _abilityActivationTypeBusinessRules = abilityActivationTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateAbilityActivationTypeResponse> Handle(CreateAbilityActivationTypeRequest request, CancellationToken cancellationToken)
    {
        RandomCodeGenerator randomCodeGenerator = new();

        AbilityActivationType abilityActivationType = _mapper.Map<AbilityActivationType>(request.CreateAbilityActivationTypeDto);
        abilityActivationType.Id = ObjectId.GenerateNewId().ToString();
        abilityActivationType.Status = true;
        abilityActivationType.IsDeleted = false;
        abilityActivationType.Code = randomCodeGenerator.GenerateUniqueCode();
        abilityActivationType.CreatedDate = DateTime.Now;

        await _abilityActivationTypeService.Create(abilityActivationType);

        CreateAbilityActivationTypeResponse mappedResponse = _mapper.Map<CreateAbilityActivationTypeResponse>(abilityActivationType);
        return mappedResponse;
    }
}

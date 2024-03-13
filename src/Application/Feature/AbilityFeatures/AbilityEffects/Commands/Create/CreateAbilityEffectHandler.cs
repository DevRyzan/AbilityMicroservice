using Application.Feature.AbilityFeatures.AbilityEffects.Rules;
using Application.Service.AbilityServices.AbilityEffectService;
using AutoMapper;
using Core.Application.Generator;
using Domain.Abilities;
using MediatR;
using MongoDB.Bson;


namespace Application.Feature.AbilityFeatures.AbilityEffects.Commands.Create;

public class CreateAbilityEffectHandler : IRequestHandler<CreateAbilityEffectRequest, CreateAbilityEffectResponse>
{
    private readonly IAbilityEffectService _abilityEffectService;
    private readonly AbilityEffectBusinessRules _abilityEffectBusinessRules;
    private readonly IMapper _mapper;

    public CreateAbilityEffectHandler(IAbilityEffectService abilityEffectService, AbilityEffectBusinessRules abilityEffectBusinessRules, IMapper mapper)
    {
        _abilityEffectService = abilityEffectService;
        _abilityEffectBusinessRules = abilityEffectBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateAbilityEffectResponse> Handle(CreateAbilityEffectRequest request, CancellationToken cancellationToken)
    {
        // Initialize a RandomCodeGenerator to generate a unique code.
        RandomCodeGenerator randomCodeGenerator = new();

        // Map the request DTO to an AbilityEffect entity.
        AbilityEffect abilityEffect = _mapper.Map<AbilityEffect>(request.CreateAbilityEffectDto);

        // Generate a new ID and set initial properties (Status, IsDeleted, Code, CreatedDate).
        abilityEffect.Id = ObjectId.GenerateNewId().ToString();
        abilityEffect.Status = true;
        abilityEffect.IsDeleted = false;
        abilityEffect.Code = randomCodeGenerator.GenerateUniqueCode();
        abilityEffect.CreatedDate = DateTime.Now;

        // Create the new AbilityEffect in the service.
        await _abilityEffectService.Create(abilityEffect);

        // Map the created AbilityEffect to the response DTO.
        CreateAbilityEffectResponse mappedResponse = _mapper.Map<CreateAbilityEffectResponse>(abilityEffect);

        // Return the mapped response.
        return mappedResponse;

    }
}

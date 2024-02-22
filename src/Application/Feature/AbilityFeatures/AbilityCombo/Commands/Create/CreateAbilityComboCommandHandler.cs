using Application.Feature.AbilityFeatures.AbilityCombo.Rules;
using Application.Service.AbilityServices.AbilityComboService;
using AutoMapper;
using Core.Application.Generator;
using MediatR;
using MongoDB.Bson;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Commands.Create;

public class CreateAbilityComboCommandHandler : IRequestHandler<CreateAbilityComboCommandRequest, CreateAbilityComboCommandResponse>
{
    private readonly IAbilityComboService _abilityComboService;
    private readonly AbilityComboBusinessRules _abilityComboBusinessRules;
    private readonly IMapper _mapper;

    public CreateAbilityComboCommandHandler(IAbilityComboService abilityComboService, AbilityComboBusinessRules abilityComboBusinessRules, IMapper mapper)
    {
        _abilityComboService = abilityComboService;
        _abilityComboBusinessRules = abilityComboBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateAbilityComboCommandResponse> Handle(CreateAbilityComboCommandRequest request, CancellationToken cancellationToken)
    {
        RandomCodeGenerator code = new RandomCodeGenerator();

        Domain.Abilities.AbilityCombo abilityCombo = _mapper.Map<Domain.Abilities.AbilityCombo>(request.CreateAbilityComboDto);

        abilityCombo.Id = ObjectId.GenerateNewId().ToString();
        abilityCombo.Status = true;
        abilityCombo.IsDeleted = false;
        abilityCombo.Code = code.GenerateUniqueCode();
        abilityCombo.CreatedDate = DateTime.Now;

        var t = await _abilityComboService.Create(abilityCombo);

        CreateAbilityComboCommandResponse mappedResponse = _mapper.Map<CreateAbilityComboCommandResponse>(abilityCombo);

        return mappedResponse;
    }
}

using Application.Service.AbilityServices.AbilityComboService;
using Application.Service.AbilityServices.AbilityLevelService;
using Application.Service.AbilityServices.AbilityService;
using AutoMapper;
using Core.Application.Generator;
using MediatR;


namespace Application.Feature.AbilityFeatures.Ability.Commands.Create;

public class CreateAbilityCommandHandler : IRequestHandler<CreateAbilityCommandRequest, CreateAbilityCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAbilityComboService _abilityComboService;
    private readonly IAbilityLevelService _abilityLevelService;
    private readonly IAbilityService _abilityService;

    public CreateAbilityCommandHandler(IMapper mapper, IAbilityService abilityService, IAbilityComboService abilityComboService, IAbilityLevelService abilityLevelService)
    {
        _mapper = mapper;
        _abilityService = abilityService;
        _abilityComboService = abilityComboService;
        _abilityLevelService = abilityLevelService;
    }

    public async Task<CreateAbilityCommandResponse> Handle(CreateAbilityCommandRequest request, CancellationToken cancellationToken)
    {
        RandomCodeGenerator codeGenerator = new RandomCodeGenerator();

        Domain.Abilities.Ability ability = _mapper.Map<Domain.Abilities.Ability>(request.CreateAbilityDto);

        ability.Code = codeGenerator.GenerateUniqueCode();
        ability.Status = true;
        ability.IsDeleted = false;
        ability.CreatedDate = DateTime.Now;

        await _abilityService.Create(ability);

        CreateAbilityCommandResponse mappedResponse = _mapper.Map<CreateAbilityCommandResponse>(ability);

        return mappedResponse;
    }

}

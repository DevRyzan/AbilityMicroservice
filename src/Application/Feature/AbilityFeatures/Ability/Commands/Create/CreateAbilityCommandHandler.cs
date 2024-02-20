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
        // Create a new instance of the RandomCodeGenerator for generating unique codes
        RandomCodeGenerator codeGenerator = new RandomCodeGenerator();

        // Map data from the incoming request DTO to a new Ability object
        Domain.Abilities.Ability ability = _mapper.Map<Domain.Abilities.Ability>(request.CreateAbilityDto);

        // Generate a unique code using the code generator
        ability.Code = codeGenerator.GenerateUniqueCode();

        // Set default values for the new Ability
        ability.Status = true;          // Assuming 'Status' is a boolean property
        ability.IsDeleted = false;      // Assuming 'IsDeleted' is a boolean property
        ability.CreatedDate = DateTime.Now;  // Set the creation date to the current date and time

        // Create the new Ability by calling the _abilityService
        await _abilityService.Create(ability);

        // Map the created Ability to the response DTO
        CreateAbilityCommandResponse mappedResponse = _mapper.Map<CreateAbilityCommandResponse>(ability);

        // Return the mapped response to the calling code
        return mappedResponse;

    }

}

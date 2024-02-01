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
        // Create an instance of the RandomCodeGenerator class for generating unique codes
        RandomCodeGenerator codeGenerator = new RandomCodeGenerator();

        // Retrieve an AbilityCombo using the specified ID from the request DTO
        Domain.Abilities.AbilityCombo abilityCombo = await _abilityComboService.GetById(id: request.CreateAbilityDto.AbilityComboId);

        // Create an instance of the Ability class and set its properties
        Domain.Abilities.Ability ability = new Domain.Abilities.Ability
        {
            // Generate a new unique identifier for HeroId
            HeroId = Guid.NewGuid(),

            // Set the AbilityCombo property with the retrieved AbilityCombo
            AbilityCombo = abilityCombo,

            // Initialize an empty list for AbilityLevels
            AbilityLevels = new List<Domain.Abilities.AbilityLevel>(),

            // Generate a unique code using the codeGenerator
            Code = codeGenerator.GenerateUniqueCode(),

            // Set the creation date to the current local time
            CreatedDate = DateTime.Now,

            // Set IsDeleted to false and Status to true
            IsDeleted = false,
            Status = true
        };

        // Iterate through the AbilityLevelIds from the request DTO and add corresponding AbilityLevels to the Ability
        foreach (var abilityLevelId in request.CreateAbilityDto.AbilityLevelIds)
        {
            // Check if the abilityLevelId is not null
            if (abilityLevelId != null)
            {
                // Retrieve an AbilityLevel using the specified ID and add it to the AbilityLevels list
                Domain.Abilities.AbilityLevel abilityLevel = await _abilityLevelService.GetById(id: abilityLevelId);
                ability.AbilityLevels.Add(abilityLevel);
            }
        }

        // Call the Create method of _abilityService to create the Ability
        await _abilityService.Create(ability);

        // Map the created Ability to a CreateAbilityCommandResponse using the mapper
        CreateAbilityCommandResponse mappedResponse = _mapper.Map<CreateAbilityCommandResponse>(ability);

        // Return the mapped response
        return mappedResponse;


    }

}

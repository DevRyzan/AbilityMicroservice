using Application.Feature.AbilityFeatures.AbilityTargetType.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeService;
using AutoMapper;
using Core.Application.Generator;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Create;

public class CreateAbilityTargetTypeCommandHandler : IRequestHandler<CreateAbilityTargetTypeCommandRequest, CreateAbilityTargetTypeCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly AbilityTargetTypeBusinessRules _abilityTargetTypeBusinessRules;
    private readonly IAbilityTargetTypeService _abilityTargetTypeService;

    public CreateAbilityTargetTypeCommandHandler(IMapper mapper, AbilityTargetTypeBusinessRules abilityTargetTypeBusinessRules, IAbilityTargetTypeService abilityTargetTypeService)
    {
        _mapper = mapper;
        _abilityTargetTypeBusinessRules = abilityTargetTypeBusinessRules;
        _abilityTargetTypeService = abilityTargetTypeService;
    }

    public async Task<CreateAbilityTargetTypeCommandResponse> Handle(CreateAbilityTargetTypeCommandRequest request, CancellationToken cancellationToken)
    {
        await _abilityTargetTypeBusinessRules.AbilityShouldBeExist(abilityId: request.CreateAbilityTargetTypeDto.AbilityId);

        // Check if the specified ability ID is available for creating an AbilityTargetType, applying business rules
        await _abilityTargetTypeBusinessRules.AbilityShouldBeAvailableForCreate(abilityId: request.CreateAbilityTargetTypeDto.AbilityId);

        // Map the data from the request DTO to an instance of AbilityTargetType
        Domain.Abilities.AbilityTargetType abilityTargetType = _mapper.Map<Domain.Abilities.AbilityTargetType>(request.CreateAbilityTargetTypeDto);

        // Create an instance of RandomCodeGenerator for generating unique codes
        RandomCodeGenerator code = new RandomCodeGenerator();

        // Set properties for the AbilityTargetType
        abilityTargetType.Status = true;
        abilityTargetType.IsDeleted = false;
        abilityTargetType.Code = code.GenerateUniqueCode(); // Generate a unique code
        abilityTargetType.CreatedDate = DateTime.Now; // Set the creation date to the current local time

        // Call the Create method of _abilityTargetTypeService to create the AbilityTargetType
        await _abilityTargetTypeService.Create(abilityTargetType);

        // Map the created AbilityTargetType to a CreateAbilityTargetTypeCommandResponse using the mapper
        CreateAbilityTargetTypeCommandResponse mappedResponse = _mapper.Map<CreateAbilityTargetTypeCommandResponse>(abilityTargetType);

        // Return the mapped response
        return mappedResponse;

    }
}

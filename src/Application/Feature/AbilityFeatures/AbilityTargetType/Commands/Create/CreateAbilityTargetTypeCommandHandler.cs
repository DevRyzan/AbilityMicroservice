using Application.Feature.AbilityFeatures.AbilityTargetType.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeService;
using AutoMapper;
using Core.Application.Generator;
using MediatR;
using MongoDB.Bson;

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

        // Map the data from the request DTO to an instance of AbilityTargetType
        Domain.Abilities.AbilityTargetType abilityTargetType = _mapper.Map<Domain.Abilities.AbilityTargetType>(request.CreateAbilityTargetTypeDto);

        // Create an instance of RandomCodeGenerator for generating unique codes
        RandomCodeGenerator code = new RandomCodeGenerator();

        // Set properties for the AbilityTargetType
        abilityTargetType.Id = ObjectId.GenerateNewId().ToString();
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

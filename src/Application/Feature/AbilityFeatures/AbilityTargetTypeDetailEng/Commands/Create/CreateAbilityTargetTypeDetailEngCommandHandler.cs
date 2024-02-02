using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeDetailEngService;
using AutoMapper;
using Core.Application.Generator;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Commands.Create;

public class CreateAbilityTargetTypeDetailEngCommandHandler : IRequestHandler<CreateAbilityTargetTypeDetailEngCommandRequest, CreateAbilityTargetTypeDetailEngCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAbilityTargetTypeDetailEngService _abilityTargetTypeDetailEngService;
    private readonly AbilityTargetTypeDetailEngBusinessRules _abilityTargetTypeDetailEngBusinessRules;

    public CreateAbilityTargetTypeDetailEngCommandHandler(IMapper mapper, IAbilityTargetTypeDetailEngService abilityTargetTypeDetailEngService, AbilityTargetTypeDetailEngBusinessRules abilityTargetTypeDetailEngBusinessRules)
    {
        _mapper = mapper;
        _abilityTargetTypeDetailEngService = abilityTargetTypeDetailEngService;
        _abilityTargetTypeDetailEngBusinessRules = abilityTargetTypeDetailEngBusinessRules;
    }

    public async Task<CreateAbilityTargetTypeDetailEngCommandResponse> Handle(CreateAbilityTargetTypeDetailEngCommandRequest request, CancellationToken cancellationToken)
    {

        // Check if the specified ability target type ID exists, applying business rules
        await _abilityTargetTypeDetailEngBusinessRules.AbilityTargetTypeShouldBeExist(abilityTargetTypeId: request.CreateAbilityTargetTypeDetailEngDto.AbilityTargetTypeId);

        // Check if the specified ability target type ID is available for creating AbilityTargetTypeDetailEng, applying business rules
        await _abilityTargetTypeDetailEngBusinessRules.AbilityTargetTypeShouldBeAvailableForCreate(abilityTargetTypeId: request.CreateAbilityTargetTypeDetailEngDto.AbilityTargetTypeId);

        // Map the data from the request DTO to an instance of AbilityTargetTypeDetailEng
        Domain.Abilities.AbilityTargetTypeDetailEng abilityTargetTypeDetailEng = _mapper.Map<Domain.Abilities.AbilityTargetTypeDetailEng>(request.CreateAbilityTargetTypeDetailEngDto);

        // Create an instance of RandomCodeGenerator for generating unique codes
        RandomCodeGenerator code = new RandomCodeGenerator();

        // Set properties for the AbilityTargetTypeDetailEng
        abilityTargetTypeDetailEng.LanguageCode = Domain.Enums.LanguageCode.EN;
        abilityTargetTypeDetailEng.Code = code.GenerateUniqueCode(); // Generate a unique code
        abilityTargetTypeDetailEng.CreatedDate = DateTime.Now; // Set the creation date to the current local time
        abilityTargetTypeDetailEng.IsDeleted = false;
        abilityTargetTypeDetailEng.Status = true;

        // Call the Create method of _abilityTargetTypeDetailEngService to create the AbilityTargetTypeDetailEng
        await _abilityTargetTypeDetailEngService.Create(abilityTargetTypeDetailEng);

        // Map the created AbilityTargetTypeDetailEng to a CreateAbilityTargetTypeDetailEngCommandResponse using the mapper
        CreateAbilityTargetTypeDetailEngCommandResponse mappedResponse = _mapper.Map<CreateAbilityTargetTypeDetailEngCommandResponse>(abilityTargetTypeDetailEng);

        // Return the mapped response
        return mappedResponse;

    }
}

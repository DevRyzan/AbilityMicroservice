using Application.Feature.AbilityFeatures.AbilityCategory.Rules;
using Application.Service.AbilitiyServices.AbilityCategoryService;
using AutoMapper;
using Core.Application.Generator;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Commands.Create;

public class CreateAbilityCategoryCommandHandler : IRequestHandler<CreateAbilityCategoryCommandRequest, CreatedAbilityCategoryCommandResponse>
{
    private readonly IAbilityCategoryService _abilityCategoryService;
    private readonly IMapper _mapper;
    private readonly AbilityCategoryBusinessRules _abilityCategoryBusinessRules;

    public CreateAbilityCategoryCommandHandler(IAbilityCategoryService abilityCategoryService, IMapper mapper, AbilityCategoryBusinessRules abilityCategoryBusinessRules)
    {
        _abilityCategoryService = abilityCategoryService;
        _mapper = mapper;
        _abilityCategoryBusinessRules = abilityCategoryBusinessRules;
    }

    public async Task<CreatedAbilityCategoryCommandResponse> Handle(CreateAbilityCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        RandomCodeGenerator code = new RandomCodeGenerator();


        // Map the request object to the AbilityCategory entity.
        Domain.Abilities.AbilityCategory mappedAbilityCategory = _mapper.Map<Domain.Abilities.AbilityCategory>(request);

        // Generate a unique code for the AbilityCategory entity.
        mappedAbilityCategory.Code = code.GenerateUniqueCode();

        // Set initial status, deletion flag, and creation timestamp for the new AbilityCategory object.
        mappedAbilityCategory.Status = true;
        mappedAbilityCategory.IsDeleted = false;
        mappedAbilityCategory.CreatedDate = DateTime.Now;

        // Call the create method of the AbilityCategoryService to add the new object to the system.
        Domain.Abilities.AbilityCategory abilityCategory = await _abilityCategoryService.Create(mappedAbilityCategory);

        // Map the created AbilityCategory object to the response DTO.
        CreatedAbilityCategoryCommandResponse mappedResponse = _mapper.Map<CreatedAbilityCategoryCommandResponse>(abilityCategory);

        // Return the mapped response object.
        return mappedResponse;
    }
}

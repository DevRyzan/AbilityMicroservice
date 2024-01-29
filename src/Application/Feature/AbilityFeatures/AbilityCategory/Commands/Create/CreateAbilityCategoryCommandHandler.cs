using Application.Feature.AbilityFeatures.AbilityCategory.Rules;
using Application.Service.AbilityServices.AbilityCategoryDetailEngService;
using Application.Service.AbilityServices.AbilityCategoryService;
using AutoMapper;
using Core.Application.Generator;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Commands.Create;

public class CreateAbilityCategoryCommandHandler : IRequestHandler<CreateAbilityCategoryCommandRequest, CreatedAbilityCategoryCommandResponse>
{
    private readonly IAbilityCategoryService _abilityCategoryService;
    private readonly IAbilityCategoryDetailEngService _abilityCategoryDetailEng;
    private readonly IMapper _mapper;
    private readonly AbilityCategoryBusinessRules _abilityCategoryBusinessRules;

    public CreateAbilityCategoryCommandHandler(IAbilityCategoryService abilityCategoryService, IAbilityCategoryDetailEngService abilityCategoryDetailEng, IMapper mapper, AbilityCategoryBusinessRules abilityCategoryBusinessRules)
    {
        _abilityCategoryService = abilityCategoryService;
        _abilityCategoryDetailEng = abilityCategoryDetailEng;
        _mapper = mapper;
        _abilityCategoryBusinessRules = abilityCategoryBusinessRules;
    }

    public async Task<CreatedAbilityCategoryCommandResponse> Handle(CreateAbilityCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified category name already exists in business rules.
        await _abilityCategoryBusinessRules.CategoryNameAlreadyExist(categoryName: request.AbilityCategoryCreateDto.Name);

        // Generate a random code for the first time.
        RandomCodeGenerator code1 = new RandomCodeGenerator();

        // Map the AbilityCategoryCreateDto to the domain model, and set initial properties.
        Domain.Abilities.AbilityCategory mappedAbilityCategory = _mapper.Map<Domain.Abilities.AbilityCategory>(request.AbilityCategoryCreateDto);
        mappedAbilityCategory.Code = code1.GenerateUniqueCode();
        mappedAbilityCategory.Status = true;
        mappedAbilityCategory.IsDeleted = false;
        mappedAbilityCategory.CreatedDate = DateTime.Now;

        // Create the AbilityCategory in the database.
        Domain.Abilities.AbilityCategory abilityCategory = await _abilityCategoryService.Create(mappedAbilityCategory);

        // Generate another random code for the second time.
        RandomCodeGenerator code2 = new RandomCodeGenerator();

        // Map the AbilityCategoryCreateDto to the AbilityCategoryDetailEng domain model, and set initial properties.
        Domain.Abilities.AbilityCategoryDetailEng abilityCategoryDetailEng = _mapper.Map<Domain.Abilities.AbilityCategoryDetailEng>(request.AbilityCategoryCreateDto);
        abilityCategoryDetailEng.AbilityCategoryId = mappedAbilityCategory.Id;
        abilityCategoryDetailEng.Code = code2.GenerateUniqueCode();
        abilityCategoryDetailEng.LanguageCode = Domain.Enums.LanguageCode.EN;
        abilityCategoryDetailEng.Status = mappedAbilityCategory.Status;
        abilityCategoryDetailEng.IsDeleted = mappedAbilityCategory.IsDeleted;
        abilityCategoryDetailEng.CreatedDate = mappedAbilityCategory.CreatedDate;

        // Create the AbilityCategoryDetailEng in the database.
        await _abilityCategoryDetailEng.Create(abilityCategoryDetailEng);

        // Map the created AbilityCategory to a response object and include additional details from the AbilityCategoryDetailEng.
        CreatedAbilityCategoryCommandResponse mappedResponse = _mapper.Map<CreatedAbilityCategoryCommandResponse>(abilityCategory);
        mappedResponse.Name = abilityCategoryDetailEng.Name;
        mappedResponse.Description = abilityCategoryDetailEng.Description;

        // Return the mapped response.
        return mappedResponse;

    }
}

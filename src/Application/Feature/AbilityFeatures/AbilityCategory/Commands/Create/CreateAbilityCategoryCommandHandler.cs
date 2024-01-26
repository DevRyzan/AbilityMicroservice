using Application.Feature.AbilityFeatures.AbilityCategory.Rules;
using Application.Service.AbilityServices.AbilityCategoryDetailEngService;
using Application.Service.AbilityServices.AbilityCategoryService;
using Application.Service.Repositories;
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
        RandomCodeGenerator code1 = new RandomCodeGenerator();

        Domain.Abilities.AbilityCategory mappedAbilityCategory = _mapper.Map<Domain.Abilities.AbilityCategory>(request);

        mappedAbilityCategory.Code = code1.GenerateUniqueCode();
        mappedAbilityCategory.Status = true;
        mappedAbilityCategory.IsDeleted = false;
        mappedAbilityCategory.CreatedDate = DateTime.Now;

        Domain.Abilities.AbilityCategory abilityCategory = await _abilityCategoryService.Create(mappedAbilityCategory);

        RandomCodeGenerator code2 = new RandomCodeGenerator();
        Domain.Abilities.AbilityCategoryDetailEng abilityCategoryDetailEng = _mapper.Map<Domain.Abilities.AbilityCategoryDetailEng>(request);

        abilityCategoryDetailEng.AbilityCategoryId = mappedAbilityCategory.Id;
        abilityCategoryDetailEng.Code = code2.GenerateUniqueCode();
        abilityCategoryDetailEng.LanguageCode = Domain.Enums.LanguageCode.EN;
        abilityCategoryDetailEng.Status = mappedAbilityCategory.Status;
        abilityCategoryDetailEng.IsDeleted = mappedAbilityCategory.IsDeleted;
        abilityCategoryDetailEng.CreatedDate = mappedAbilityCategory.CreatedDate;

        await _abilityCategoryDetailEng.Create(abilityCategoryDetailEng);

        CreatedAbilityCategoryCommandResponse mappedResponse = _mapper.Map<CreatedAbilityCategoryCommandResponse>(abilityCategory);
        mappedResponse.Name = abilityCategoryDetailEng.Name;
        mappedResponse.Description = abilityCategoryDetailEng.Description;

        return mappedResponse;
    }
}

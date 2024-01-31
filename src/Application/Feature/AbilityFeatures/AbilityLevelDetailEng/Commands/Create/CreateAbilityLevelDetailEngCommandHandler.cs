using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Rules;
using Application.Service.AbilityServices.AbilityLevelDetailEngService;
using AutoMapper;
using Core.Application.Generator;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Commands.Create;

public class CreateAbilityLevelDetailEngCommandHandler : IRequestHandler<CreateAbilityLevelDetailEngCommandRequest, CreateAbilityLevelDetailEngCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAbilityLevelDetailEngService _abilityLevelDetailEngService;
    private readonly AbilityLevelDetailEngBusinessRules _abilityLevelDetailEngBusinessRules;

    public CreateAbilityLevelDetailEngCommandHandler(IMapper mapper, IAbilityLevelDetailEngService abilityLevelDetailEngService, AbilityLevelDetailEngBusinessRules abilityLevelDetailEngBusinessRules)
    {
        _mapper = mapper;
        _abilityLevelDetailEngService = abilityLevelDetailEngService;
        _abilityLevelDetailEngBusinessRules = abilityLevelDetailEngBusinessRules;
    }

    public async Task<CreateAbilityLevelDetailEngCommandResponse> Handle(CreateAbilityLevelDetailEngCommandRequest request, CancellationToken cancellationToken)
    {
        await _abilityLevelDetailEngBusinessRules.AbilityLevelShouldBeExist(abilityLevelId: request.CreateAbilityLevelDetailEng.AbilityLevelId);
        await _abilityLevelDetailEngBusinessRules.AbilityLevelIdAlreadyHaveDetailForCreate(abilityLevelId: request.CreateAbilityLevelDetailEng.AbilityLevelId);

        RandomCodeGenerator code = new RandomCodeGenerator();
        Domain.Abilities.AbilityLevelDetailEng abilityLevelDetailEng = _mapper.Map<Domain.Abilities.AbilityLevelDetailEng>(request.CreateAbilityLevelDetailEng);

        abilityLevelDetailEng.LanguageCode = Domain.Enums.LanguageCode.EN;
        abilityLevelDetailEng.Status = true;
        abilityLevelDetailEng.Code = code.GenerateUniqueCode();
        abilityLevelDetailEng.IsDeleted = false;
        abilityLevelDetailEng.CreatedDate = DateTime.Now;

        await _abilityLevelDetailEngService.Create(abilityLevelDetailEng: abilityLevelDetailEng);

        CreateAbilityLevelDetailEngCommandResponse mappedResponse = _mapper.Map<CreateAbilityLevelDetailEngCommandResponse>(abilityLevelDetailEng);
        return mappedResponse;
    }
}

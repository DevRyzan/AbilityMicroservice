using Application.Feature.AbilityFeatures.AbilityCategory.Rules;
using Application.Service.AbilityServices.AbilityCategoryDetailEngService;
using Application.Service.AbilityServices.AbilityCategoryService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Commands.ChangeStatus;

public class ChangeStatusAbilityCategoryCommandHandler : IRequestHandler<ChangeStatusAbilityCategoryCommandRequest, ChangeStatusAbilityCategoryCommandResponse>
{
    private readonly IAbilityCategoryService _abilityCategoryService;
    private readonly IAbilityCategoryDetailEngService _abilityCategoryDetailEng;
    private readonly IMapper _mapper;
    private readonly AbilityCategoryBusinessRules _abilityCategoryBusinessRules;

    public ChangeStatusAbilityCategoryCommandHandler(IAbilityCategoryService abilityCategoryService, IAbilityCategoryDetailEngService abilityCategoryDetailEng, IMapper mapper, AbilityCategoryBusinessRules abilityCategoryBusinessRules)
    {
        _abilityCategoryService = abilityCategoryService;
        _abilityCategoryDetailEng = abilityCategoryDetailEng;
        _mapper = mapper;
        _abilityCategoryBusinessRules = abilityCategoryBusinessRules;
    }

    public async Task<ChangeStatusAbilityCategoryCommandResponse> Handle(ChangeStatusAbilityCategoryCommandRequest request, CancellationToken cancellationToken)
    {

        Domain.Abilities.AbilityCategory abilityCategory = await _abilityCategoryService.GetById(request.Id);

        abilityCategory.Status = abilityCategory.Status == true ? false : true;

        abilityCategory.UpdatedDate = DateTime.UtcNow;

        await _abilityCategoryService.Update(abilityCategory);

        Domain.Abilities.AbilityCategoryDetailEng abilityCategoryDetailEng = await _abilityCategoryDetailEng.GetByAbilityId(abilityId: abilityCategory.Id);
        abilityCategoryDetailEng.Status = abilityCategory.Status;
        abilityCategory.UpdatedDate = abilityCategory.UpdatedDate;

        await _abilityCategoryDetailEng.Update(abilityCategoryDetailEng);


        ChangeStatusAbilityCategoryCommandResponse mappedResponse = _mapper.Map<ChangeStatusAbilityCategoryCommandResponse>(abilityCategory);

        return mappedResponse;

    }
}

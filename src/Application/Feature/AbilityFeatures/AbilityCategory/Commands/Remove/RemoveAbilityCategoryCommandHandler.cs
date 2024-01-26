using Application.Feature.AbilityFeatures.AbilityCategory.Rules;
using Application.Service.AbilityServices.AbilityCategoryDetailEngService;
using Application.Service.AbilityServices.AbilityCategoryService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Commands.Remove;

public class RemoveAbilityCategoryCommandHandler : IRequestHandler<RemoveAbilityCategoryCommandRequest, RemovedAbilityCategoryCommandResponse>
{
    private readonly IAbilityCategoryService _abilityCategoryService;
    private readonly IAbilityCategoryDetailEngService _abilityCategoryDetailEng;
    private readonly IMapper _mapper;
    private readonly AbilityCategoryBusinessRules _abilityCategoryBusinessRule;

    public RemoveAbilityCategoryCommandHandler(IAbilityCategoryService abilityCategoryService, IAbilityCategoryDetailEngService abilityCategoryDetailEng, IMapper mapper, AbilityCategoryBusinessRules abilityCategoryBusinessRule)
    {
        _abilityCategoryService = abilityCategoryService;
        _abilityCategoryDetailEng = abilityCategoryDetailEng;
        _mapper = mapper;
        _abilityCategoryBusinessRule = abilityCategoryBusinessRule;
    }

    public async Task<RemovedAbilityCategoryCommandResponse> Handle(RemoveAbilityCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        await _abilityCategoryBusinessRule.IdShouldBeExist(id: request.Id);
        await _abilityCategoryBusinessRule.RemoveCondition(request.Id);

        Domain.Abilities.AbilityCategory abilityCategory = await _abilityCategoryService.GetById(request.Id);

        Domain.Abilities.AbilityCategoryDetailEng abilityCategoryDetailEng = await _abilityCategoryDetailEng.GetByAbilityId(abilityId:request.Id);


        await _abilityCategoryDetailEng.Remove(abilityCategoryDetailEng);
        await _abilityCategoryService.Remove(abilityCategory);

        RemovedAbilityCategoryCommandResponse mappedResponse = _mapper.Map<RemovedAbilityCategoryCommandResponse>(abilityCategoryDetailEng);

        return mappedResponse;
    }
}

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
        // Check if the specified ID exists in the business rules for AbilityCategory removal.
        await _abilityCategoryBusinessRule.IdShouldBeExist(id: request.AbilityCategoryRemoveDto.Id);

        // Remove any additional conditions related to the AbilityCategory removal.
        await _abilityCategoryBusinessRule.RemoveCondition(request.AbilityCategoryRemoveDto.Id);

        // Retrieve the AbilityCategory using the provided ID.
        Domain.Abilities.AbilityCategory abilityCategory = await _abilityCategoryService.GetById(request.AbilityCategoryRemoveDto.Id);

        // Retrieve the corresponding AbilityCategoryDetailEng using the AbilityCategory's ID.
        Domain.Abilities.AbilityCategoryDetailEng abilityCategoryDetailEng = await _abilityCategoryDetailEng.GetByAbilityId(abilityId: request.AbilityCategoryRemoveDto.Id);

        // Remove the AbilityCategoryDetailEng from the database.
        await _abilityCategoryDetailEng.Remove(abilityCategoryDetailEng);

        // Remove the AbilityCategory from the database.
        await _abilityCategoryService.Remove(abilityCategory);

        // Map the removed AbilityCategoryDetailEng to a response object.
        RemovedAbilityCategoryCommandResponse mappedResponse = _mapper.Map<RemovedAbilityCategoryCommandResponse>(abilityCategoryDetailEng);

        // Return the mapped response.
        return mappedResponse;

    }
}

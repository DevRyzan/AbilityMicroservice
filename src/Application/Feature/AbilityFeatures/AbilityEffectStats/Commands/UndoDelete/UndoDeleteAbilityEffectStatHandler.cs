using Application.Feature.AbilityFeatures.AbilityEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.UndoDelete;

public class UndoDeleteAbilityEffectStatHandler : IRequestHandler<UndoDeleteAbilityEffectStatRequest, UndoDeleteAbilityEffectStatResponse>
{
    private readonly IAbilityEffectStatService _abilityEffectStatService;
    private readonly AbilityEffectStatBusinessRules _abilityEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilityEffectStatHandler(IAbilityEffectStatService abilityEffectStatService, AbilityEffectStatBusinessRules abilityEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEffectStatService = abilityEffectStatService;
        _abilityEffectStatBusinessRules = abilityEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilityEffectStatResponse> Handle(UndoDeleteAbilityEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Check if the ID exists using business rules.
        await _abilityEffectStatBusinessRules.IdShouldBeExist(request.UndoDeleteAbilityEffectStatDto.Id);

        // Get the AbilityEffectStat entity by ID.
        AbilityEffectStat abilityEffectStat = await _abilityEffectStatService.GetById(request.UndoDeleteAbilityEffectStatDto.Id);

        // Update the entity to mark it as not deleted.
        abilityEffectStat.IsDeleted = false;
        abilityEffectStat.UpdatedDate = DateTime.Now;

        // Update the AbilityEffectStat entity in the database.
        await _abilityEffectStatService.Update(abilityEffectStat);

        // Map the updated AbilityEffectStat entity to the response DTO.
        UndoDeleteAbilityEffectStatResponse mappedResponse = _mapper.Map<UndoDeleteAbilityEffectStatResponse>(abilityEffectStat);

        // Return the mapped response.
        return mappedResponse;

    }
}

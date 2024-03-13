using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEnemyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.UndoDelete;

public class UndoDeleteAbilityEnemyEffectStatHandler : IRequestHandler<UndoDeleteAbilityEnemyEffectStatRequest, UndoDeleteAbilityEnemyEffectStatResponse>
{
    private readonly IAbilityEnemyEffectStatService _abilityEnemyEffectStatService;
    private readonly AbilityEnemyEffectStatBusinessRules _abilityEnemyEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilityEnemyEffectStatHandler(IAbilityEnemyEffectStatService abilityEnemyEffectStatService, AbilityEnemyEffectStatBusinessRules abilityEnemyEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEnemyEffectStatService = abilityEnemyEffectStatService;
        _abilityEnemyEffectStatBusinessRules = abilityEnemyEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilityEnemyEffectStatResponse> Handle(UndoDeleteAbilityEnemyEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ID exists before attempting to undo delete
        await _abilityEnemyEffectStatBusinessRules.IdShouldBeExist(request.UndoDeleteAbilityEnemyEffectStatDto.Id);

        // Retrieve the AbilityEnemyEffectStat using the specified ID
        AbilityEnemyEffectStat abilityEnemyEffectStat = await _abilityEnemyEffectStatService.GetById(request.UndoDeleteAbilityEnemyEffectStatDto.Id);

        // Set IsDeleted to false to undo the delete
        abilityEnemyEffectStat.IsDeleted = false;

        // Update the UpdatedDate to the current date and time
        abilityEnemyEffectStat.UpdatedDate = DateTime.Now;

        // Call the service to perform the update (undo delete)
        await _abilityEnemyEffectStatService.Update(abilityEnemyEffectStat);

        // Map the undone AbilityEnemyEffectStat to the response DTO
        UndoDeleteAbilityEnemyEffectStatResponse mappedResponse = _mapper.Map<UndoDeleteAbilityEnemyEffectStatResponse>(abilityEnemyEffectStat);

        // Return the mapped response
        return mappedResponse;

    }
}

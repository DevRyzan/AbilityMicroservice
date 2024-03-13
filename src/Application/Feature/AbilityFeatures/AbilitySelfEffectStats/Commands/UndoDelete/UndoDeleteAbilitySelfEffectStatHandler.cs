using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Rules;
using Application.Service.AbilityServices.AbilitySelfEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.UndoDelete;

public class UndoDeleteAbilitySelfEffectStatHandler : IRequestHandler<UndoDeleteAbilitySelfEffectStatRequest, UndoDeleteAbilitySelfEffectStatResponse>
{
    private readonly IAbilitySelfEffectStatService _abilitySelfEffectStatService;
    private readonly AbilitySelfEffectStatBusinessRules _abilitySelfEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilitySelfEffectStatHandler(IAbilitySelfEffectStatService abilitySelfEffectStatService, AbilitySelfEffectStatBusinessRules abilitySelfEffectStatBusinessRules, IMapper mapper)
    {
        _abilitySelfEffectStatService = abilitySelfEffectStatService;
        _abilitySelfEffectStatBusinessRules = abilitySelfEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilitySelfEffectStatResponse> Handle(UndoDeleteAbilitySelfEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the provided ID exists before attempting to undo the delete
        await _abilitySelfEffectStatBusinessRules.IdShouldBeExist(request.UndoDeleteAbilitySelfEffectStatDto.Id);

        // Retrieve the AbilitySelfEffectStat entity from the service by ID
        AbilitySelfEffectStat abilitySelfEffectStat = await _abilitySelfEffectStatService.GetById(request.UndoDeleteAbilitySelfEffectStatDto.Id);

        // Undo the deletion by marking the entity as not deleted and updating the timestamp
        abilitySelfEffectStat.IsDeleted = false;
        abilitySelfEffectStat.UpdatedDate = DateTime.Now;

        // Update the entity in the database
        await _abilitySelfEffectStatService.Update(abilitySelfEffectStat);

        // Map the undone entity to the corresponding response DTO
        UndoDeleteAbilitySelfEffectStatResponse mappedResponse = _mapper.Map<UndoDeleteAbilitySelfEffectStatResponse>(abilitySelfEffectStat);

        // Return the mapped response
        return mappedResponse;

    }
}

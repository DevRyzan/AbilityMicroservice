using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityAllyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.Delete;

public class DeleteAbilityAllyEffectStatHandler : IRequestHandler<DeleteAbilityAllyEffectStatRequest, DeleteAbilityAllyEffectStatResponse>
{
    private readonly IAbilityAllyEffectStatService _abilityAllyEffectStatService;
    private readonly AbilityAllyEffectStatsBusinessRules _abilityAllyEffectStatsBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilityAllyEffectStatHandler(IAbilityAllyEffectStatService abilityAllyEffectStatService, AbilityAllyEffectStatsBusinessRules abilityAllyEffectStatsBusinessRules, IMapper mapper)
    {
        _abilityAllyEffectStatService = abilityAllyEffectStatService;
        _abilityAllyEffectStatsBusinessRules = abilityAllyEffectStatsBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilityAllyEffectStatResponse> Handle(DeleteAbilityAllyEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityAllyEffectStatsBusinessRules.IdShouldBeExist(request.DeleteAbilityAllyEffectStatDto.Id);

        // Retrieve the AbilityAllyEffectStat associated with the provided ID from the service.
        AbilityAllyEffectStat abilityAllyEffectStat = await _abilityAllyEffectStatService.GetById(request.DeleteAbilityAllyEffectStatDto.Id);

        // Set IsDeleted to true, indicating that the record is flagged as deleted.
        abilityAllyEffectStat.IsDeleted = true;

        // Set Status to false, indicating that the record is no longer active.
        abilityAllyEffectStat.Status = false;

        // Set the deletion timestamp for the AbilityAllyEffectStat.
        abilityAllyEffectStat.DeletedDate = DateTime.Now;

        // Delete the AbilityAllyEffectStat in the database using the service.
        await _abilityAllyEffectStatService.Delete(abilityAllyEffectStat);

        // Map the deleted AbilityAllyEffectStat to the response DTO.
        DeleteAbilityAllyEffectStatResponse mappedResponse = _mapper.Map<DeleteAbilityAllyEffectStatResponse>(abilityAllyEffectStat);

        // Return the mapped response.
        return mappedResponse;

    }
}

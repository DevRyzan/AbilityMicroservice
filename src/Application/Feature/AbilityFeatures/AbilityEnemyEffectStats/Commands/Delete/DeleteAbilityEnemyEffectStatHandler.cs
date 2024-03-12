using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEnemyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.Delete;

public class DeleteAbilityEnemyEffectStatHandler : IRequestHandler<DeleteAbilityEnemyEffectStatRequest, DeleteAbilityEnemyEffectStatResponse>
{
    private readonly IAbilityEnemyEffectStatService _abilityEnemyEffectStatService;
    private readonly AbilityEnemyEffectStatBusinessRules _abilityEnemyEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilityEnemyEffectStatHandler(IAbilityEnemyEffectStatService abilityEnemyEffectStatService, AbilityEnemyEffectStatBusinessRules abilityEnemyEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEnemyEffectStatService = abilityEnemyEffectStatService;
        _abilityEnemyEffectStatBusinessRules = abilityEnemyEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilityEnemyEffectStatResponse> Handle(DeleteAbilityEnemyEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ID exists before attempting to delete
        await _abilityEnemyEffectStatBusinessRules.IdShouldBeExist(request.DeleteAbilityEnemyEffectStatDto.Id);

        // Retrieve the AbilityEnemyEffectStat using the specified ID
        AbilityEnemyEffectStat abilityEnemyEffectStat = await _abilityEnemyEffectStatService.GetById(request.DeleteAbilityEnemyEffectStatDto.Id);

        // Set IsDeleted to true to mark the record as deleted
        abilityEnemyEffectStat.IsDeleted = true;

        // Set Status to false to mark the record as inactive
        abilityEnemyEffectStat.Status = false;

        // Set DeletedDate to the current date and time
        abilityEnemyEffectStat.DeletedDate = DateTime.Now;

        // Call the service to perform the delete operation
        await _abilityEnemyEffectStatService.Delete(abilityEnemyEffectStat);

        // Map the deleted AbilityEnemyEffectStat to the response DTO
        DeleteAbilityEnemyEffectStatResponse mappedResponse = _mapper.Map<DeleteAbilityEnemyEffectStatResponse>(abilityEnemyEffectStat);

        // Return the mapped response
        return mappedResponse;

    }
}

using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEnemyEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.Update;

public class UpdateAbilityEnemyEffectStatHandler : IRequestHandler<UpdateAbilityEnemyEffectStatRequest, UpdateAbilityEnemyEffectStatResponse>
{
    private readonly IAbilityEnemyEffectStatService _abilityEnemyEffectStatService;
    private readonly AbilityEnemyEffectStatBusinessRules _abilityEnemyEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityEnemyEffectStatHandler(IAbilityEnemyEffectStatService abilityEnemyEffectStatService, AbilityEnemyEffectStatBusinessRules abilityEnemyEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEnemyEffectStatService = abilityEnemyEffectStatService;
        _abilityEnemyEffectStatBusinessRules = abilityEnemyEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityEnemyEffectStatResponse> Handle(UpdateAbilityEnemyEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ID exists before attempting the update
        await _abilityEnemyEffectStatBusinessRules.IdShouldBeExist(request.UpdateAbilityEnemyEffectStatDto.Id);

        // Retrieve the AbilityEnemyEffectStat using the specified ID
        AbilityEnemyEffectStat abilityEnemyEffectStat = await _abilityEnemyEffectStatService.GetById(request.UpdateAbilityEnemyEffectStatDto.Id);

        // Map the properties from the request DTO to the existing AbilityEnemyEffectStat
        _mapper.Map(request.UpdateAbilityEnemyEffectStatDto, abilityEnemyEffectStat);

        // Update the UpdatedDate to the current date and time
        abilityEnemyEffectStat.UpdatedDate = DateTime.Now;

        // Call the service to perform the update
        await _abilityEnemyEffectStatService.Update(abilityEnemyEffectStat);

        // Map the updated AbilityEnemyEffectStat to the response DTO
        UpdateAbilityEnemyEffectStatResponse mappedResponse = _mapper.Map<UpdateAbilityEnemyEffectStatResponse>(abilityEnemyEffectStat);

        // Return the mapped response
        return mappedResponse;

    }
}

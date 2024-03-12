using Application.Feature.AbilityFeatures.AbilityAttackStats.Rules;
using Application.Service.AbilityServices.AbilityAttackStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Remove;

public class RemoveAbilityAttackStatHandler : IRequestHandler<RemoveAbilityAttackStatRequest, RemoveAbilityAttackStatResponse>
{
    private readonly IAbilityAttackStatService _abilityAttackStatService;
    private readonly AbilityAttackStatBusinessRules _abilityAttackStatBusinessRules;
    private readonly IMapper _mapper;

    public RemoveAbilityAttackStatHandler(IAbilityAttackStatService abilityAttackStatService, AbilityAttackStatBusinessRules abilityAttackStatBusinessRules, IMapper mapper)
    {
        _abilityAttackStatService = abilityAttackStatService;
        _abilityAttackStatBusinessRules = abilityAttackStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveAbilityAttackStatResponse> Handle(RemoveAbilityAttackStatRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityAttackStatBusinessRules.IdShouldBeExist(request.RemoveAbilityAttackStatDto.Id);

        // Check additional conditions for the removal process.
        await _abilityAttackStatBusinessRules.RemoveCondition(request.RemoveAbilityAttackStatDto.Id);

        // Retrieve the AbilityAttackStat associated with the provided ID from the service.
        AbilityAttackStat abilityAttackStat = await _abilityAttackStatService.GetById(request.RemoveAbilityAttackStatDto.Id);

        // Remove the AbilityAttackStat from the database using the service.
        await _abilityAttackStatService.Remove(abilityAttackStat);

        // Map the removed AbilityAttackStat to the response DTO.
        RemoveAbilityAttackStatResponse mappedResponse = _mapper.Map<RemoveAbilityAttackStatResponse>(abilityAttackStat);

        // Return the mapped response.
        return mappedResponse;

    }
}

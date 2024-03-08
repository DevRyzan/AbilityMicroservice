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
        await _abilityAttackStatBusinessRules.IdShouldBeExist(request.RemoveAbilityAttackStatDto.Id);
        await _abilityAttackStatBusinessRules.RemoveCondition(request.RemoveAbilityAttackStatDto.Id);

        AbilityAttackStat abilityAttackStat = await _abilityAttackStatService.GetById(request.RemoveAbilityAttackStatDto.Id);

        await _abilityAttackStatService.Remove(abilityAttackStat);

        RemoveAbilityAttackStatResponse mappedResponse = _mapper.Map<RemoveAbilityAttackStatResponse>(abilityAttackStat);
        return mappedResponse;
    }
}

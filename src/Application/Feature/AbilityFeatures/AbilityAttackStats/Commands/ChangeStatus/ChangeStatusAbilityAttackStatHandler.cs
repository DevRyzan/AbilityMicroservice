using Application.Feature.AbilityFeatures.AbilityAttackStats.Rules;
using Application.Service.AbilityServices.AbilityAttackStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.ChangeStatus;

public class ChangeStatusAbilityAttackStatHandler : IRequestHandler<ChangeStatusAbilityAttackStatRequest, ChangeStatusAbilityAttackStatResponse>
{
    private readonly IAbilityAttackStatService _abilityAttackStatService;
    private readonly AbilityAttackStatBusinessRules _abilityAttackStatBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityAttackStatHandler(IAbilityAttackStatService abilityAttackStatService, AbilityAttackStatBusinessRules abilityAttackStatBusinessRules, IMapper mapper)
    {
        _abilityAttackStatService = abilityAttackStatService;
        _abilityAttackStatBusinessRules = abilityAttackStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityAttackStatResponse> Handle(ChangeStatusAbilityAttackStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityAttackStatBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityAttackStatDto.Id);

        AbilityAttackStat abilityAttackStat = await _abilityAttackStatService.GetById(request.ChangeStatusAbilityAttackStatDto.Id);
        abilityAttackStat.Status = abilityAttackStat.Status == true ? false : true;
        abilityAttackStat.UpdatedDate = DateTime.Now;

        await _abilityAttackStatService.Update(abilityAttackStat);

        ChangeStatusAbilityAttackStatResponse mappedResponse = _mapper.Map<ChangeStatusAbilityAttackStatResponse>(abilityAttackStat);
        return mappedResponse;
    }
}

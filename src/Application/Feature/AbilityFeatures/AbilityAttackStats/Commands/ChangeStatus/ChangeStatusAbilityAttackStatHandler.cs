using Application.Feature.AbilityFeatures.AbilityAttackStats.Rules;
using Application.Service.AbilityServices.AbilityAttackStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.ChangeStatus;

public class ChangeStatusAbilityAttackStatHandler : IRequestHandler<ChangeStatusAbilityAttackStatRequest, ChangeStatusAbilityAttackStatResponse>
{
    private readonly IAbilityAttackStatService _abilityTargetTypeService;
    private readonly AbilityAttackStatBusinessRules _abilityTargetTypeBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityAttackStatHandler(IAbilityAttackStatService abilityTargetTypeService, AbilityAttackStatBusinessRules abilityTargetTypeBusinessRules, IMapper mapper)
    {
        _abilityTargetTypeService = abilityTargetTypeService;
        _abilityTargetTypeBusinessRules = abilityTargetTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityAttackStatResponse> Handle(ChangeStatusAbilityAttackStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityTargetTypeBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityAttackStatDto.Id);

        AbilityAttackStat abilityAttackStat = await _abilityTargetTypeService.GetById(request.ChangeStatusAbilityAttackStatDto.Id);
        abilityAttackStat.Status = abilityAttackStat.Status == true ? false : true;
        abilityAttackStat.UpdatedDate = DateTime.Now;

        await _abilityTargetTypeService.Update(abilityAttackStat);

        ChangeStatusAbilityAttackStatResponse mappedResponse = _mapper.Map<ChangeStatusAbilityAttackStatResponse>(abilityAttackStat);
        return mappedResponse;
    }
}

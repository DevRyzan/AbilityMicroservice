using Application.Feature.AbilityFeatures.AbilityEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.ChangeStatus;

public class ChangeStatusAbilityEffectStatHandler : IRequestHandler<ChangeStatusAbilityEffectStatRequest, ChangeStatusAbilityEffectStatResponse>
{
    private readonly IAbilityEffectStatService _abilityEffectStatService;
    private readonly AbilityEffectStatBusinessRules _abilityEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityEffectStatHandler(IAbilityEffectStatService abilityEffectStatService, AbilityEffectStatBusinessRules abilityEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEffectStatService = abilityEffectStatService;
        _abilityEffectStatBusinessRules = abilityEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityEffectStatResponse> Handle(ChangeStatusAbilityEffectStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityEffectStatBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityEffectStatDto.Id);
        AbilityEffectStat abilityEffectStat = await _abilityEffectStatService.GetById(request.ChangeStatusAbilityEffectStatDto.Id);

        abilityEffectStat.Status = abilityEffectStat.Status == true ? false : true;
        abilityEffectStat.UpdatedDate = DateTime.Now;

        await _abilityEffectStatService.Update(abilityEffectStat);

        ChangeStatusAbilityEffectStatResponse mappedResponse = _mapper.Map<ChangeStatusAbilityEffectStatResponse>(abilityEffectStat);
        return mappedResponse;

    }
}

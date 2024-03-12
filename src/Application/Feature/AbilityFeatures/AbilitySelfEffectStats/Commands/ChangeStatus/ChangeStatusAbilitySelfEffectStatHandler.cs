using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Rules;
using Application.Service.AbilityServices.AbilitySelfEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.ChangeStatus;

public class ChangeStatusAbilitySelfEffectStatHandler : IRequestHandler<ChangeStatusAbilitySelfEffectStatRequest, ChangeStatusAbilitySelfEffectStatResponse>
{
    private readonly IAbilitySelfEffectStatService _abilitySelfEffectStatService;
    private readonly AbilitySelfEffectStatBusinessRules _abilitySelfEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilitySelfEffectStatHandler(IAbilitySelfEffectStatService abilitySelfEffectStatService, AbilitySelfEffectStatBusinessRules abilitySelfEffectStatBusinessRules, IMapper mapper)
    {
        _abilitySelfEffectStatService = abilitySelfEffectStatService;
        _abilitySelfEffectStatBusinessRules = abilitySelfEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilitySelfEffectStatResponse> Handle(ChangeStatusAbilitySelfEffectStatRequest request, CancellationToken cancellationToken)
    {
        await _abilitySelfEffectStatBusinessRules.IdShouldBeExist(request.ChangeStatusAbilitySelfEffectStatDto.Id);

        AbilitySelfEffectStat abilitySelfEffectStat = await _abilitySelfEffectStatService.GetById(request.ChangeStatusAbilitySelfEffectStatDto.Id);

        abilitySelfEffectStat.Status = abilitySelfEffectStat.Status == true ? false : true;
        abilitySelfEffectStat.UpdatedDate = DateTime.Now;

        await _abilitySelfEffectStatService.Update(abilitySelfEffectStat);

        ChangeStatusAbilitySelfEffectStatResponse mappedResponse = _mapper.Map<ChangeStatusAbilitySelfEffectStatResponse>(abilitySelfEffectStat);
        return mappedResponse;
    }
}

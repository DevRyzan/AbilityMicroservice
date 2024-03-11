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
        await _abilitySelfEffectStatBusinessRules.IdShouldBeExist(request.UndoDeleteAbilitySelfEffectStatDto.Id);

        AbilitySelfEffectStat abilitySelfEffectStat = await _abilitySelfEffectStatService.GetById(request.UndoDeleteAbilitySelfEffectStatDto.Id);
        abilitySelfEffectStat.IsDeleted = false;
        abilitySelfEffectStat.UpdatedDate = DateTime.Now;

        await _abilitySelfEffectStatService.Update(abilitySelfEffectStat);

        UndoDeleteAbilitySelfEffectStatResponse mappedResponse = _mapper.Map<UndoDeleteAbilitySelfEffectStatResponse>(abilitySelfEffectStat);
        return mappedResponse;
    }
}

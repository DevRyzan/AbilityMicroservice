using Application.Feature.AbilityFeatures.AbilityEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.UndoDelete;

public class UndoDeleteAbilityEffectStatHandler : IRequestHandler<UndoDeleteAbilityEffectStatRequest, UndoDeleteAbilityEffectStatResponse>
{
    private readonly IAbilityEffectStatService _abilityEffectStatService;
    private readonly AbilityEffectStatBusinessRules _abilityEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilityEffectStatHandler(IAbilityEffectStatService abilityEffectStatService, AbilityEffectStatBusinessRules abilityEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEffectStatService = abilityEffectStatService;
        _abilityEffectStatBusinessRules = abilityEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilityEffectStatResponse> Handle(UndoDeleteAbilityEffectStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityEffectStatBusinessRules.IdShouldBeExist(request.UndoDeleteAbilityEffectStatDto.Id);
        AbilityEffectStat abilityEffectStat = await _abilityEffectStatService.GetById(request.UndoDeleteAbilityEffectStatDto.Id);
        abilityEffectStat.IsDeleted = false;
        abilityEffectStat.UpdatedDate = DateTime.Now;

        await _abilityEffectStatService.Update(abilityEffectStat);

        UndoDeleteAbilityEffectStatResponse mappedResponse = _mapper.Map<UndoDeleteAbilityEffectStatResponse>(abilityEffectStat);
        return mappedResponse;
    }
}

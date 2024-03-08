using Application.Feature.AbilityFeatures.AbilityAttackStats.Rules;
using Application.Service.AbilityServices.AbilityAttackStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.UndoDelete;

public class UndoDeleteAbilityAttackStatHandler : IRequestHandler<UndoDeleteAbilityAttackStatRequest, UndoDeleteAbilityAttackStatResponse>
{
    private readonly IAbilityAttackStatService _abilityAttackStatService;
    private readonly AbilityAttackStatBusinessRules _abilityAttackStatBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilityAttackStatHandler(IAbilityAttackStatService abilityAttackStatService, AbilityAttackStatBusinessRules abilityAttackStatBusinessRules, IMapper mapper)
    {
        _abilityAttackStatService = abilityAttackStatService;
        _abilityAttackStatBusinessRules = abilityAttackStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilityAttackStatResponse> Handle(UndoDeleteAbilityAttackStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityAttackStatBusinessRules.IdShouldBeExist(request.UndoDeleteAbilityAttackStatDto.Id);
        AbilityAttackStat abilityAttackStat = await _abilityAttackStatService.GetById(request.UndoDeleteAbilityAttackStatDto.Id);

        abilityAttackStat.IsDeleted = false;
        abilityAttackStat.UpdatedDate = DateTime.Now;

        await _abilityAttackStatService.Update(abilityAttackStat);

        UndoDeleteAbilityAttackStatResponse mappedResponse = _mapper.Map<UndoDeleteAbilityAttackStatResponse>(abilityAttackStat);
        return mappedResponse;
    }
}

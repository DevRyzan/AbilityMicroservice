using Application.Feature.AbilityFeatures.AbilityAttackStats.Rules;
using Application.Service.AbilityServices.AbilityAttackStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Update;

public class UpdateAbilityAttackStatHandler : IRequestHandler<UpdateAbilityAttackStatRequest, UpdateAbilityAttackStatResponse>
{
    private readonly IAbilityAttackStatService _abilityAttackStatService;
    private readonly AbilityAttackStatBusinessRules _abilityAttackStatBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityAttackStatHandler(IAbilityAttackStatService abilityAttackStatService, AbilityAttackStatBusinessRules abilityAttackStatBusinessRules, IMapper mapper)
    {
        _abilityAttackStatService = abilityAttackStatService;
        _abilityAttackStatBusinessRules = abilityAttackStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityAttackStatResponse> Handle(UpdateAbilityAttackStatRequest request, CancellationToken cancellationToken)
    {
        await _abilityAttackStatBusinessRules.IdShouldBeExist(request.UpdateAbilityAttackStatDto.Id);
        AbilityAttackStat abilityAttackStat = await _abilityAttackStatService.GetById(request.UpdateAbilityAttackStatDto.Id);

        _mapper.Map(request.UpdateAbilityAttackStatDto, abilityAttackStat);
        abilityAttackStat.UpdatedDate = DateTime.Now;

        await _abilityAttackStatService.Update(abilityAttackStat);

        UpdateAbilityAttackStatResponse mappedResponse = _mapper.Map<UpdateAbilityAttackStatResponse>(abilityAttackStat);
        return mappedResponse;

    }
}

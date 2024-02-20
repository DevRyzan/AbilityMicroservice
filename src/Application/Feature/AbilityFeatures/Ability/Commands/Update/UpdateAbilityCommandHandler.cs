using Application.Feature.AbilityFeatures.Ability.Rules;
using Application.Service.AbilityServices.AbilityService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.Ability.Commands.Update;

public class UpdateAbilityCommandHandler : IRequestHandler<UpdateAbilityCommandRequest, UpdateAbilityCommandResponse>
{
    private readonly IAbilityService _abilityService;
    private readonly AbilityBusinessRules _abilityBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityCommandHandler(IAbilityService abilityService, AbilityBusinessRules abilityBusinessRules, IMapper mapper)
    {
        _abilityService = abilityService;
        _abilityBusinessRules = abilityBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityCommandResponse> Handle(UpdateAbilityCommandRequest request, CancellationToken cancellationToken)
    {
        await _abilityBusinessRules.IdShouldBeExist(request.UpdateAbilityDto.Id);

        Domain.Abilities.Ability ability = await _abilityService.GetById(request.UpdateAbilityDto.Id);

        ability.Name = request.UpdateAbilityDto.Name;
        ability.Description = request.UpdateAbilityDto.Description;
        ability.CastTimeTypeValue = request.UpdateAbilityDto.CastTimeTypeValue;
        ability.Cooldown = request.UpdateAbilityDto.Cooldown;
        ability.Radius = request.UpdateAbilityDto.Radius;
        ability.Damage = request.UpdateAbilityDto.Damage;
        ability.IsCondition = request.UpdateAbilityDto.IsCondition;
        ability.IsTrigger = request.UpdateAbilityDto.IsTrigger;
        ability.IsHaveCombo = request.UpdateAbilityDto.IsHaveCombo;
        ability.Cost = request.UpdateAbilityDto.Cost;
        ability.IsTargeted = request.UpdateAbilityDto.IsTargeted;
        ability.IsBlockable = request.UpdateAbilityDto.IsBlockable;
        ability.IsCharging = request.UpdateAbilityDto.IsCharging;
        ability.IsHaveDisable = request.UpdateAbilityDto.IsHaveDisable;
        ability.AbilityLevelUpgradeFrequency = request.UpdateAbilityDto.AbilityLevelUpgradeFrequency;
        ability.UpdatedDate = DateTime.Now;

        await _abilityService.Update(ability);

        UpdateAbilityCommandResponse mappedResponse = _mapper.Map<UpdateAbilityCommandResponse>(ability);

        return mappedResponse;
    }
}

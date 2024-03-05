using Application.Feature.AbilityFeatures.AbilityDamageTypes.Rules;
using Application.Service.AbilityServices.AbilityDamageTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Remove;

public class RemoveAbilityDamageTypeHandler : IRequestHandler<RemoveAbilityDamageTypeRequest, RemoveAbilityDamageTypeResponse>
{
    private readonly IAbilityDamageTypeService _abilityDamageTypeService;
    private readonly AbilityDamageTypeBusinessRules _abilityDamageTypeBusinessRules;
    private readonly IMapper _mapper;

    public RemoveAbilityDamageTypeHandler(IAbilityDamageTypeService abilityDamageTypeService, AbilityDamageTypeBusinessRules abilityDamageTypeBusinessRules, IMapper mapper)
    {
        _abilityDamageTypeService = abilityDamageTypeService;
        _abilityDamageTypeBusinessRules = abilityDamageTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveAbilityDamageTypeResponse> Handle(RemoveAbilityDamageTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityDamageTypeBusinessRules.IdShouldBeExist(request.RemoveAbilityDamageTypeDto.Id);
        await _abilityDamageTypeBusinessRules.RemoveCondition(request.RemoveAbilityDamageTypeDto.Id);

        AbilityDamageType abilityDamageType = await _abilityDamageTypeService.GetById(request.RemoveAbilityDamageTypeDto.Id);

        await _abilityDamageTypeService.Remove(abilityDamageType);

        RemoveAbilityDamageTypeResponse mappedResponse = _mapper.Map<RemoveAbilityDamageTypeResponse>(abilityDamageType);
        return mappedResponse;
    }
}

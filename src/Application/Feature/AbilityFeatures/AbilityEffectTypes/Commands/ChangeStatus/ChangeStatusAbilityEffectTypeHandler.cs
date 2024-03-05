using Application.Feature.AbilityFeatures.AbilityEffectTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.ChangeStatus;

public class ChangeStatusAbilityEffectTypeHandler : IRequestHandler<ChangeStatusAbilityEffectTypeRequest, ChangeStatusAbilityEffectTypeResponse>
{
    private readonly IAbilityEffectTypeService _abilityTypeService;
    private readonly AbilityEffectTypeBusinessRules _abilityEffectTypeBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityEffectTypeHandler(IAbilityEffectTypeService abilityTypeService, AbilityEffectTypeBusinessRules abilityEffectTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityEffectTypeBusinessRules = abilityEffectTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityEffectTypeResponse> Handle(ChangeStatusAbilityEffectTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityEffectTypeBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityEffectTypeDto.Id);

        AbilityEffectType abilityEffectType = await _abilityTypeService.GetById(request.ChangeStatusAbilityEffectTypeDto.Id);
        abilityEffectType.Status = abilityEffectType.Status == true ? false : true;
        abilityEffectType.UpdatedDate = DateTime.Now;

        await _abilityTypeService.Update(abilityEffectType);

        ChangeStatusAbilityEffectTypeResponse mappedResponse = _mapper.Map<ChangeStatusAbilityEffectTypeResponse>(abilityEffectType);
        return mappedResponse;
    }
}

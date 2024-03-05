using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectDisableTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.ChangeStatus;

public class ChangeStatusAbilityEffectDisableTypeHandler : IRequestHandler<ChangeStatusAbilityEffectDisableTypeRequest, ChangeStatusAbilityEffectDisableTypeResponse>
{
    private readonly IAbilityEffectDisableTypeService _abilityEffectDisableTypeService;
    private readonly AbilityEffectDisableTypeBusinessRules _abilityEffectDisableTypeBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityEffectDisableTypeHandler(IAbilityEffectDisableTypeService abilityEffectDisableTypeService, AbilityEffectDisableTypeBusinessRules abilityEffectDisableTypeBusinessRules, IMapper mapper)
    {
        _abilityEffectDisableTypeService = abilityEffectDisableTypeService;
        _abilityEffectDisableTypeBusinessRules = abilityEffectDisableTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityEffectDisableTypeResponse> Handle(ChangeStatusAbilityEffectDisableTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityEffectDisableTypeBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityEffectDisableTypeDto.Id);

        AbilityEffectDisableType abilityEffectDisableType = await _abilityEffectDisableTypeService.GetById(request.ChangeStatusAbilityEffectDisableTypeDto.Id);
        abilityEffectDisableType.Status = abilityEffectDisableType.Status == true ? false : true;
        abilityEffectDisableType.UpdatedDate = DateTime.Now;

        await _abilityEffectDisableTypeService.Update(abilityEffectDisableType);

        ChangeStatusAbilityEffectDisableTypeResponse mappedResponse = _mapper.Map<ChangeStatusAbilityEffectDisableTypeResponse>(abilityEffectDisableType);
        return mappedResponse;
    }
}

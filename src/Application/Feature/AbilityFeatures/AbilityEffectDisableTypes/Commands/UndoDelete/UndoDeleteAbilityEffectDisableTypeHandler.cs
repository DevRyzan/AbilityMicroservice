using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectDisableTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.UndoDelete;

public class UndoDeleteAbilityEffectDisableTypeHandler : IRequestHandler<UndoDeleteAbilityEffectDisableTypeRequest, UndoDeleteAbilityEffectDisableTypeResponse>
{
    private readonly IAbilityEffectDisableTypeService _abilityEffectDisableTypeService;
    private readonly AbilityEffectDisableTypeBusinessRules _abilityEffectDisableTypeBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilityEffectDisableTypeHandler(IAbilityEffectDisableTypeService abilityEffectDisableTypeService, AbilityEffectDisableTypeBusinessRules abilityEffectDisableTypeBusinessRules, IMapper mapper)
    {
        _abilityEffectDisableTypeService = abilityEffectDisableTypeService;
        _abilityEffectDisableTypeBusinessRules = abilityEffectDisableTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilityEffectDisableTypeResponse> Handle(UndoDeleteAbilityEffectDisableTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityEffectDisableTypeBusinessRules.IdShouldBeExist(request.UndoDeleteAbilityEffectDisableTypeDto.Id);

        AbilityEffectDisableType abilityEffectDisableType = await _abilityEffectDisableTypeService.GetById(request.UndoDeleteAbilityEffectDisableTypeDto.Id);

        abilityEffectDisableType.IsDeleted = false;
        abilityEffectDisableType.UpdatedDate = DateTime.Now;

        await _abilityEffectDisableTypeService.Update(abilityEffectDisableType);

        UndoDeleteAbilityEffectDisableTypeResponse mappedResponse = _mapper.Map<UndoDeleteAbilityEffectDisableTypeResponse>(abilityEffectDisableType);
        return mappedResponse;
    }
}

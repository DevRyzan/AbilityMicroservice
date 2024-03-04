using Application.Feature.AbilityFeatures.AbilityEffectTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;



namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.UndoDelete;

public class UndoDeleteAbilityEffectTypeHandler : IRequestHandler<UndoDeleteAbilityEffectTypeRequest, UndoDeleteAbilityEffectTypeResponse>
{
    private readonly IAbilityEffectTypeService _abilityTypeService;
    private readonly AbilityEffectTypeBusinessRules _abilityEffectTypeBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilityEffectTypeHandler(IAbilityEffectTypeService abilityTypeService, AbilityEffectTypeBusinessRules abilityEffectTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityEffectTypeBusinessRules = abilityEffectTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilityEffectTypeResponse> Handle(UndoDeleteAbilityEffectTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityEffectTypeBusinessRules.IdShouldBeExist(request.UndoDeleteAbilityEffectTypeDto.Id);

        AbilityEffectType abilityEffectType = await _abilityTypeService.GetById(request.UndoDeleteAbilityEffectTypeDto.Id);

        abilityEffectType.IsDeleted = false;
        abilityEffectType.UpdatedDate = DateTime.Now;

        await _abilityTypeService.Update(abilityEffectType);

        UndoDeleteAbilityEffectTypeResponse mappedResponse = _mapper.Map<UndoDeleteAbilityEffectTypeResponse>(abilityEffectType);
        return mappedResponse;

    }
}

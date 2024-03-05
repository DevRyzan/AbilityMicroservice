using Application.Feature.AbilityFeatures.AbilityDamageTypes.Rules;
using Application.Service.AbilityServices.AbilityDamageTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.UndoDelete;

public class UndoDeleteAbilityDamageTypeHandler : IRequestHandler<UndoDeleteAbilityDamageTypeRequest, UndoDeleteAbilityDamageTypeResponse>
{
    private readonly IAbilityDamageTypeService _abilityDamageTypeService;
    private readonly AbilityDamageTypeBusinessRules _abilityDamageTypeBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilityDamageTypeHandler(IAbilityDamageTypeService abilityDamageTypeService, AbilityDamageTypeBusinessRules abilityDamageTypeBusinessRules, IMapper mapper)
    {
        _abilityDamageTypeService = abilityDamageTypeService;
        _abilityDamageTypeBusinessRules = abilityDamageTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilityDamageTypeResponse> Handle(UndoDeleteAbilityDamageTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityDamageTypeBusinessRules.IdShouldBeExist(request.UndoDeleteAbilityDamageTypeDto.Id);

        AbilityDamageType abilityDamageType = await _abilityDamageTypeService.GetById(request.UndoDeleteAbilityDamageTypeDto.Id);
        abilityDamageType.IsDeleted = false;
        abilityDamageType.UpdatedDate = DateTime.Now;

        await _abilityDamageTypeService.Update(abilityDamageType);

        UndoDeleteAbilityDamageTypeResponse mappedResponse = _mapper.Map<UndoDeleteAbilityDamageTypeResponse>(abilityDamageType);
        return mappedResponse;


    }
}

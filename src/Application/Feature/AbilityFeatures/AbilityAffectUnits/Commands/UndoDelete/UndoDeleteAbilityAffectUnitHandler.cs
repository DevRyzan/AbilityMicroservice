using Application.Feature.AbilityFeatures.AbilityAffectUnits.Rules;
using Application.Service.AbilityServices.AbilityAffectUnitService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.UndoDelete;

public class UndoDeleteAbilityAffectUnitHandler : IRequestHandler<UndoDeleteAbilityAffectUnitRequest, UndoDeleteAbilityAffectUnitResponse>
{
    private readonly IAbilityAffectUnitService _abilityAffectUnitService;
    private readonly AbilityAffectUnitBusinessRules _abilityAffectUnitBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilityAffectUnitHandler(IAbilityAffectUnitService abilityAffectUnitService, AbilityAffectUnitBusinessRules abilityAffectUnitBusinessRules, IMapper mapper)
    {
        _abilityAffectUnitService = abilityAffectUnitService;
        _abilityAffectUnitBusinessRules = abilityAffectUnitBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilityAffectUnitResponse> Handle(UndoDeleteAbilityAffectUnitRequest request, CancellationToken cancellationToken)
    {
        await _abilityAffectUnitBusinessRules.IdShouldBeExist(request.UndoDeleteAbilityAffectUnitDto.Id);

        AbilityAffectUnit abilityAffectUnit = await _abilityAffectUnitService.GetById(request.UndoDeleteAbilityAffectUnitDto.Id);
        abilityAffectUnit.IsDeleted = false;
        abilityAffectUnit.UpdatedDate = DateTime.Now;

        await _abilityAffectUnitService.Update(abilityAffectUnit);

        UndoDeleteAbilityAffectUnitResponse mappedResponse = _mapper.Map<UndoDeleteAbilityAffectUnitResponse>(abilityAffectUnit);
        return mappedResponse;
    }
}

using Application.Feature.AbilityFeatures.AbilityAffectUnits.Rules;
using Application.Service.AbilityServices.AbilityAffectUnitService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.ChangeStatus;

public class ChangeStatusAbilityAffectUnitHandler : IRequestHandler<ChangeStatusAbilityAffectUnitRequest, ChangeStatusAbilityAffectUnitResponse>
{
    private readonly IAbilityAffectUnitService _abilityAffectUnitService;
    private readonly AbilityAffectUnitBusinessRules _abilityAffectUnitBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityAffectUnitHandler(IAbilityAffectUnitService abilityAffectUnitService, AbilityAffectUnitBusinessRules abilityAffectUnitBusinessRules, IMapper mapper)
    {
        _abilityAffectUnitService = abilityAffectUnitService;
        _abilityAffectUnitBusinessRules = abilityAffectUnitBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityAffectUnitResponse> Handle(ChangeStatusAbilityAffectUnitRequest request, CancellationToken cancellationToken)
    {
        await _abilityAffectUnitBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityAffectUnitDto.Id);

        AbilityAffectUnit abilityAffectUnit = await _abilityAffectUnitService.GetById(request.ChangeStatusAbilityAffectUnitDto.Id);
        abilityAffectUnit.Status = abilityAffectUnit.Status == true ? false : true;
        abilityAffectUnit.UpdatedDate = DateTime.Now;

        await _abilityAffectUnitService.Update(abilityAffectUnit);

        ChangeStatusAbilityAffectUnitResponse mappedResponse = _mapper.Map<ChangeStatusAbilityAffectUnitResponse>(abilityAffectUnit);
        return mappedResponse;
    }
}

using Application.Feature.AbilityFeatures.AbilityAffectUnits.Rules;
using Application.Service.AbilityServices.AbilityAffectUnitService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Update;

public class UpdateAbilityAffectUnitHandler : IRequestHandler<UpdateAbilityAffectUnitRequest, UpdateAbilityAffectUnitResponse>
{
    private readonly IAbilityAffectUnitService _abilityAffectUnitService;
    private readonly AbilityAffectUnitBusinessRules _abilityAffectUnitBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityAffectUnitHandler(IAbilityAffectUnitService abilityAffectUnitService, AbilityAffectUnitBusinessRules abilityAffectUnitBusinessRules, IMapper mapper)
    {
        _abilityAffectUnitService = abilityAffectUnitService;
        _abilityAffectUnitBusinessRules = abilityAffectUnitBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityAffectUnitResponse> Handle(UpdateAbilityAffectUnitRequest request, CancellationToken cancellationToken)
    {
        await _abilityAffectUnitBusinessRules.IdShouldBeExist(request.UpdateAbilityAffectUnitDto.Id);

        AbilityAffectUnit abilityAffectUnit = await _abilityAffectUnitService.GetById(request.UpdateAbilityAffectUnitDto.Id);
        abilityAffectUnit.Name = request.UpdateAbilityAffectUnitDto.Name;
        abilityAffectUnit.UpdatedDate = DateTime.Now;

        await _abilityAffectUnitService.Update(abilityAffectUnit);

        UpdateAbilityAffectUnitResponse mappedResponse = _mapper.Map<UpdateAbilityAffectUnitResponse>(abilityAffectUnit);
        return mappedResponse;
    }
}

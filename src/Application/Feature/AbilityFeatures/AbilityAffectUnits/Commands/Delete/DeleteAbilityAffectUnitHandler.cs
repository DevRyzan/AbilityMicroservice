using Application.Feature.AbilityFeatures.AbilityAffectUnits.Rules;
using Application.Service.AbilityServices.AbilityAffectUnitService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Delete;

public class DeleteAbilityAffectUnitHandler : IRequestHandler<DeleteAbilityAffectUnitRequest, DeleteAbilityAffectUnitResponse>
{
    private readonly IAbilityAffectUnitService _abilityAffectUnitService;
    private readonly AbilityAffectUnitBusinessRules _abilityAffectUnitBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilityAffectUnitHandler(IAbilityAffectUnitService abilityAffectUnitService, AbilityAffectUnitBusinessRules abilityAffectUnitBusinessRules, IMapper mapper)
    {
        _abilityAffectUnitService = abilityAffectUnitService;
        _abilityAffectUnitBusinessRules = abilityAffectUnitBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilityAffectUnitResponse> Handle(DeleteAbilityAffectUnitRequest request, CancellationToken cancellationToken)
    {
        await _abilityAffectUnitBusinessRules.IdShouldBeExist(request.DeleteAbilityAffectUnitDto.Id);

        AbilityAffectUnit abilityAffectUnit = await _abilityAffectUnitService.GetById(request.DeleteAbilityAffectUnitDto.Id);
        abilityAffectUnit.IsDeleted = true;
        abilityAffectUnit.Status = false;
        abilityAffectUnit.DeletedDate = DateTime.Now;

        await _abilityAffectUnitService.Delete(abilityAffectUnit);

        DeleteAbilityAffectUnitResponse mappedResponse = _mapper.Map<DeleteAbilityAffectUnitResponse>(abilityAffectUnit);
        return mappedResponse;
    }
}

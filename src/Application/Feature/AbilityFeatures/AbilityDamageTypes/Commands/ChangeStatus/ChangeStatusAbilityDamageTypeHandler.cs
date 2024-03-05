using Application.Feature.AbilityFeatures.AbilityDamageTypes.Rules;
using Application.Service.AbilityServices.AbilityDamageTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.ChangeStatus;

public class ChangeStatusAbilityDamageTypeHandler : IRequestHandler<ChangeStatusAbilityDamageTypeRequest, ChangeStatusAbilityDamageTypeResponse>
{
    private readonly IAbilityDamageTypeService _abilityDamageTypeService;
    private readonly AbilityDamageTypeBusinessRules _abilityDamageTypeBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityDamageTypeHandler(IAbilityDamageTypeService abilityDamageTypeService, AbilityDamageTypeBusinessRules abilityDamageTypeBusinessRules, IMapper mapper)
    {
        _abilityDamageTypeService = abilityDamageTypeService;
        _abilityDamageTypeBusinessRules = abilityDamageTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityDamageTypeResponse> Handle(ChangeStatusAbilityDamageTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityDamageTypeBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityDamageTypeDto.Id);

        AbilityDamageType abilityDamageType = await _abilityDamageTypeService.GetById(request.ChangeStatusAbilityDamageTypeDto.Id);
        abilityDamageType.Status = abilityDamageType.Status == true ? false : true;
        abilityDamageType.UpdatedDate = DateTime.Now;

        await _abilityDamageTypeService.Update(abilityDamageType);

        ChangeStatusAbilityDamageTypeResponse mappedResponse = _mapper.Map<ChangeStatusAbilityDamageTypeResponse>(abilityDamageType);
        return mappedResponse;
    }
}

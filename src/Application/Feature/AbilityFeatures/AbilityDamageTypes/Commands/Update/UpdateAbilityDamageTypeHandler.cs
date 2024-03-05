using Application.Feature.AbilityFeatures.AbilityDamageTypes.Rules;
using Application.Service.AbilityServices.AbilityDamageTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Update;

public class UpdateAbilityDamageTypeHandler : IRequestHandler<UpdateAbilityDamageTypeRequest, UpdateAbilityDamageTypeResponse>
{
    private readonly IAbilityDamageTypeService _abilityDamageTypeService;
    private readonly AbilityDamageTypeBusinessRules _abilityDamageTypeBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityDamageTypeHandler(IAbilityDamageTypeService abilityDamageTypeService, AbilityDamageTypeBusinessRules abilityDamageTypeBusinessRules, IMapper mapper)
    {
        _abilityDamageTypeService = abilityDamageTypeService;
        _abilityDamageTypeBusinessRules = abilityDamageTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityDamageTypeResponse> Handle(UpdateAbilityDamageTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityDamageTypeBusinessRules.IdShouldBeExist(request.UpdateAbilityDamageTypeDto.Id);

        AbilityDamageType abilityDamageType = await _abilityDamageTypeService.GetById(request.UpdateAbilityDamageTypeDto.Id);
        abilityDamageType.Name = request.UpdateAbilityDamageTypeDto.Name;
        abilityDamageType.Description = request.UpdateAbilityDamageTypeDto.Description;
        abilityDamageType.UpdatedDate = DateTime.Now;

        await _abilityDamageTypeService.Update(abilityDamageType);

        UpdateAbilityDamageTypeResponse mappedResponse = _mapper.Map<UpdateAbilityDamageTypeResponse>(abilityDamageType);
        return mappedResponse;
    }
}

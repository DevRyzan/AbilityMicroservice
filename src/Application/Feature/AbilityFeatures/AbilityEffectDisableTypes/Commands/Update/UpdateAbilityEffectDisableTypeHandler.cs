using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectDisableTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;



namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Update;

public class UpdateAbilityEffectDisableTypeHandler : IRequestHandler<UpdateAbilityEffectDisableTypeRequest, UpdateAbilityEffectDisableTypeResponse>
{
    private readonly IAbilityEffectDisableTypeService _abilityEffectDisableTypeService;
    private readonly AbilityEffectDisableTypeBusinessRules _abilityEffectDisableTypeBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityEffectDisableTypeHandler(IAbilityEffectDisableTypeService abilityEffectDisableTypeService, AbilityEffectDisableTypeBusinessRules abilityEffectDisableTypeBusinessRules, IMapper mapper)
    {
        _abilityEffectDisableTypeService = abilityEffectDisableTypeService;
        _abilityEffectDisableTypeBusinessRules = abilityEffectDisableTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityEffectDisableTypeResponse> Handle(UpdateAbilityEffectDisableTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityEffectDisableTypeBusinessRules.IdShouldBeExist(request.UpdateAbilityEffectDisableTypeDto.Id);

        AbilityEffectDisableType abilityEffectDisableType = await _abilityEffectDisableTypeService.GetById(request.UpdateAbilityEffectDisableTypeDto.Id);
        abilityEffectDisableType.Name = request.UpdateAbilityEffectDisableTypeDto.Name;
        abilityEffectDisableType.Description = request.UpdateAbilityEffectDisableTypeDto.Description;
        abilityEffectDisableType.UpdatedDate = DateTime.Now;

        await _abilityEffectDisableTypeService.Update(abilityEffectDisableType);

        UpdateAbilityEffectDisableTypeResponse mappedResponse = _mapper.Map<UpdateAbilityEffectDisableTypeResponse>(abilityEffectDisableType);
        return mappedResponse;
    }
}

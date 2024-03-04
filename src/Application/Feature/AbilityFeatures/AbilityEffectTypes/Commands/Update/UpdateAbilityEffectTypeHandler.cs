using Application.Feature.AbilityFeatures.AbilityEffectTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Update;

public class UpdateAbilityEffectTypeHandler : IRequestHandler<UpdateAbilityEffectTypeRequest, UpdateAbilityEffectTypeResponse>
{
    private readonly IAbilityEffectTypeService _abilityTypeService;
    private readonly AbilityEffectTypeBusinessRules _abilityEffectTypeBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityEffectTypeHandler(IAbilityEffectTypeService abilityTypeService, AbilityEffectTypeBusinessRules abilityEffectTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityEffectTypeBusinessRules = abilityEffectTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityEffectTypeResponse> Handle(UpdateAbilityEffectTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityEffectTypeBusinessRules.IdShouldBeExist(request.UpdateAbilityEffectTypeDto.Id);

        AbilityEffectType abilityEffectType = await _abilityTypeService.GetById(request.UpdateAbilityEffectTypeDto.Id);

        abilityEffectType.Name = request.UpdateAbilityEffectTypeDto.Name;
        abilityEffectType.Description = request.UpdateAbilityEffectTypeDto.Description;
        abilityEffectType.UpdatedDate = DateTime.Now;

        await _abilityTypeService.Update(abilityEffectType);

        UpdateAbilityEffectTypeResponse mappedResponse = _mapper.Map<UpdateAbilityEffectTypeResponse>(abilityEffectType);

        return mappedResponse;
    }
}

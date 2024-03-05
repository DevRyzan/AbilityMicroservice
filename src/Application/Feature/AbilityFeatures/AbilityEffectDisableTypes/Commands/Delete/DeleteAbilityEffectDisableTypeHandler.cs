using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectDisableTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Delete;

public class DeleteAbilityEffectDisableTypeHandler : IRequestHandler<DeleteAbilityEffectDisableTypeRequest, DeleteAbilityEffectDisableTypeResponse>
{
    private readonly IAbilityEffectDisableTypeService _abilityEffectDisableTypeService;
    private readonly AbilityEffectDisableTypeBusinessRules _abilityEffectDisableTypeBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilityEffectDisableTypeHandler(IAbilityEffectDisableTypeService abilityEffectDisableTypeService, AbilityEffectDisableTypeBusinessRules abilityEffectDisableTypeBusinessRules, IMapper mapper)
    {
        _abilityEffectDisableTypeService = abilityEffectDisableTypeService;
        _abilityEffectDisableTypeBusinessRules = abilityEffectDisableTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilityEffectDisableTypeResponse> Handle(DeleteAbilityEffectDisableTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityEffectDisableTypeBusinessRules.IdShouldBeExist(request.DeleteAbilityEffectDisableTypeDto.Id);

        AbilityEffectDisableType abilityEffectDisableType = await _abilityEffectDisableTypeService.GetById(request.DeleteAbilityEffectDisableTypeDto.Id);
        abilityEffectDisableType.IsDeleted = true;
        abilityEffectDisableType.Status = false;
        abilityEffectDisableType.DeletedDate = DateTime.Now;

        await _abilityEffectDisableTypeService.Delete(abilityEffectDisableType);

        DeleteAbilityEffectDisableTypeResponse mappedResponse = _mapper.Map<DeleteAbilityEffectDisableTypeResponse>(abilityEffectDisableType);
        return mappedResponse;
    }
}

using Application.Feature.AbilityFeatures.AbilityEffectTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Delete;

public class DeleteAbilityEffectTypeHandler : IRequestHandler<DeleteAbilityEffectTypeRequest, DeleteAbilityEffectTypeResponse>
{

    private readonly IAbilityEffectTypeService _abilityTypeService;
    private readonly AbilityEffectTypeBusinessRules _abilityEffectTypeBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilityEffectTypeHandler(IAbilityEffectTypeService abilityTypeService, AbilityEffectTypeBusinessRules abilityEffectTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityEffectTypeBusinessRules = abilityEffectTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilityEffectTypeResponse> Handle(DeleteAbilityEffectTypeRequest request, CancellationToken cancellationToken)
    {

        await _abilityEffectTypeBusinessRules.IdShouldBeExist(request.DeleteAbilityEffectTypeDto.Id);

        AbilityEffectType abilityEffectType = await _abilityTypeService.GetById(request.DeleteAbilityEffectTypeDto.Id);

        abilityEffectType.IsDeleted = true;
        abilityEffectType.Status = false;
        abilityEffectType.DeletedDate = DateTime.Now;

        await _abilityTypeService.Delete(abilityEffectType);

        DeleteAbilityEffectTypeResponse mappedResponse = _mapper.Map<DeleteAbilityEffectTypeResponse>(abilityEffectType);
        return mappedResponse;
    }
}

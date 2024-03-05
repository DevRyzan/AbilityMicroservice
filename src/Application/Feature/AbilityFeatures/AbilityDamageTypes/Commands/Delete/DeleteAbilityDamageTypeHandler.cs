using Application.Feature.AbilityFeatures.AbilityDamageTypes.Rules;
using Application.Service.AbilityServices.AbilityDamageTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Delete;

public class DeleteAbilityDamageTypeHandler : IRequestHandler<DeleteAbilityDamageTypeRequest, DeleteAbilityDamageTypeResponse>
{
    private readonly IAbilityDamageTypeService _abilityDamageTypeService;
    private readonly AbilityDamageTypeBusinessRules _abilityDamageTypeBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilityDamageTypeHandler(IAbilityDamageTypeService abilityDamageTypeService, AbilityDamageTypeBusinessRules abilityDamageTypeBusinessRules, IMapper mapper)
    {
        _abilityDamageTypeService = abilityDamageTypeService;
        _abilityDamageTypeBusinessRules = abilityDamageTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilityDamageTypeResponse> Handle(DeleteAbilityDamageTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityDamageTypeBusinessRules.IdShouldBeExist(request.DeleteAbilityDamageTypeDto.Id);

        AbilityDamageType abilityDamageType = await _abilityDamageTypeService.GetById(request.DeleteAbilityDamageTypeDto.Id);
        abilityDamageType.IsDeleted = true;
        abilityDamageType.Status = false;
        abilityDamageType.DeletedDate = DateTime.Now;

        await _abilityDamageTypeService.Delete(abilityDamageType);

        DeleteAbilityDamageTypeResponse mappedResponse = _mapper.Map<DeleteAbilityDamageTypeResponse>(abilityDamageType);
        return mappedResponse;
    }
}

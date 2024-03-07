using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Service.AbilityServices.AbilityActivationTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Remove;

public class RemoveAbilityActivationTypeHandler : IRequestHandler<RemoveAbilityActivationTypeRequest, RemoveAbilityActivationTypeResponse>
{
    private readonly IAbilityActivationTypeService _abilityActivationTypeService;
    private readonly AbilityActivationTypeBusinessRules _abilityActivationTypeBusinessRules;
    private readonly IMapper _mapper;

    public RemoveAbilityActivationTypeHandler(IAbilityActivationTypeService abilityActivationTypeService, AbilityActivationTypeBusinessRules abilityActivationTypeBusinessRules, IMapper mapper)
    {
        _abilityActivationTypeService = abilityActivationTypeService;
        _abilityActivationTypeBusinessRules = abilityActivationTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveAbilityActivationTypeResponse> Handle(RemoveAbilityActivationTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityActivationTypeBusinessRules.IdShouldBeExist(request.RemoveAbilityActivationTypeDto.Id);
        await _abilityActivationTypeBusinessRules.RemoveCondition(request.RemoveAbilityActivationTypeDto.Id);

        AbilityActivationType abilityActivationType = await _abilityActivationTypeService.GetById(request.RemoveAbilityActivationTypeDto.Id);

        await _abilityActivationTypeService.Remove(abilityActivationType);

        RemoveAbilityActivationTypeResponse mappedResponse = _mapper.Map<RemoveAbilityActivationTypeResponse>(abilityActivationType);
        return mappedResponse;
    }
}

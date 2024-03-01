using Application.Feature.AbilityFeatures.AbilityTypes.Rules;
using Application.Service.AbilityServices.AbilityTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityTypes.Commands.Remove;

public class RemoveAbilityTypeCommandHandler : IRequestHandler<RemoveAbilityTypeCommandRequest, RemoveAbilityTypeCommandResponse>
{
    private readonly IAbilityTypeService _abilityTypeService;
    private readonly AbilityTypeBusinessRules _abilityTypeBusinessRules;
    private readonly IMapper _mapper;

    public RemoveAbilityTypeCommandHandler(IAbilityTypeService abilityTypeService, AbilityTypeBusinessRules abilityTypeBusinessRules, IMapper mapper)
    {
        _abilityTypeService = abilityTypeService;
        _abilityTypeBusinessRules = abilityTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveAbilityTypeCommandResponse> Handle(RemoveAbilityTypeCommandRequest request, CancellationToken cancellationToken)
    {
        await _abilityTypeBusinessRules.IdShouldBeExist(request.RemoveAbilityTypeDto.Id);
        await _abilityTypeBusinessRules.RemoveCondition(request.RemoveAbilityTypeDto.Id);

        AbilityType abilityType = await _abilityTypeService.GetById(request.RemoveAbilityTypeDto.Id);
        await _abilityTypeService.Remove(abilityType);

        RemoveAbilityTypeCommandResponse mappedResponse = _mapper.Map<RemoveAbilityTypeCommandResponse>(abilityType);

        return mappedResponse;

    }
}

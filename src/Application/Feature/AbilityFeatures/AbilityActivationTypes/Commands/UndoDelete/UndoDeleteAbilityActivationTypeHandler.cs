using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Service.AbilityServices.AbilityActivationTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.UndoDelete;

public class UndoDeleteAbilityActivationTypeHandler : IRequestHandler<UndoDeleteAbilityActivationTypeRequest, UndoDeleteAbilityActivationTypeResponse>
{
    private readonly IAbilityActivationTypeService _abilityActivationTypeService;
    private readonly AbilityActivationTypeBusinessRules _abilityActivationTypeBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteAbilityActivationTypeHandler(IAbilityActivationTypeService abilityActivationTypeService, AbilityActivationTypeBusinessRules abilityActivationTypeBusinessRules, IMapper mapper)
    {
        _abilityActivationTypeService = abilityActivationTypeService;
        _abilityActivationTypeBusinessRules = abilityActivationTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteAbilityActivationTypeResponse> Handle(UndoDeleteAbilityActivationTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityActivationTypeBusinessRules.IdShouldBeExist(request.UndoDeleteAbilityActivationTypeDto.Id);

        AbilityActivationType abilityActivationType = await _abilityActivationTypeService.GetById(request.UndoDeleteAbilityActivationTypeDto.Id);
        abilityActivationType.IsDeleted = false;
        abilityActivationType.UpdatedDate = DateTime.Now;

        await _abilityActivationTypeService.Update(abilityActivationType);

        UndoDeleteAbilityActivationTypeResponse mappedResponse = _mapper.Map<UndoDeleteAbilityActivationTypeResponse>(abilityActivationType);
        return mappedResponse;
    }
}

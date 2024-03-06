using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Service.AbilityServices.AbilityActivationTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.ChangeStatus;

public class ChangeStatusAbilityActivationTypeHandler : IRequestHandler<ChangeStatusAbilityActivationTypeRequest, ChangeStatusAbilityActivationTypeResponse>
{
    private readonly IAbilityActivationTypeService _abilityActivationTypeService;
    private readonly AbilityActivationTypeBusinessRules _abilityActivationTypeBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilityActivationTypeHandler(IAbilityActivationTypeService abilityActivationTypeService, AbilityActivationTypeBusinessRules abilityActivationTypeBusinessRules, IMapper mapper)
    {
        _abilityActivationTypeService = abilityActivationTypeService;
        _abilityActivationTypeBusinessRules = abilityActivationTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilityActivationTypeResponse> Handle(ChangeStatusAbilityActivationTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityActivationTypeBusinessRules.IdShouldBeExist(request.ChangeStatusAbilityActivationTypeDto.Id);

        AbilityActivationType abilityActivationType = await _abilityActivationTypeService.GetById(request.ChangeStatusAbilityActivationTypeDto.Id);
        abilityActivationType.Status = abilityActivationType.Status == true ? false : true;
        abilityActivationType.UpdatedDate = DateTime.Now;

        await _abilityActivationTypeService.Update(abilityActivationType);

        ChangeStatusAbilityActivationTypeResponse mappedResponse = _mapper.Map<ChangeStatusAbilityActivationTypeResponse>(abilityActivationType);
        return mappedResponse;
    }
}

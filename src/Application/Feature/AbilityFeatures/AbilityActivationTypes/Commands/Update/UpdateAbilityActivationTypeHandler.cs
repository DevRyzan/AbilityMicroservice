using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Service.AbilityServices.AbilityActivationTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Update;

public class UpdateAbilityActivationTypeHandler : IRequestHandler<UpdateAbilityActivationTypeRequest, UpdateAbilityActivationTypeResponse>
{
    private readonly IAbilityActivationTypeService _abilityActivationTypeService;
    private readonly AbilityActivationTypeBusinessRules _abilityActivationTypeBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityActivationTypeHandler(IAbilityActivationTypeService abilityActivationTypeService, AbilityActivationTypeBusinessRules abilityActivationTypeBusinessRules, IMapper mapper)
    {
        _abilityActivationTypeService = abilityActivationTypeService;
        _abilityActivationTypeBusinessRules = abilityActivationTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityActivationTypeResponse> Handle(UpdateAbilityActivationTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityActivationTypeBusinessRules.IdShouldBeExist(request.UpdateAbilityActivationTypeDto.Id);

        AbilityActivationType abilityActivationType = await _abilityActivationTypeService.GetById(request.UpdateAbilityActivationTypeDto.Id);
        abilityActivationType.Name = request.UpdateAbilityActivationTypeDto.Name;
        abilityActivationType.Description = request.UpdateAbilityActivationTypeDto.Description;
        abilityActivationType.UpdatedDate = DateTime.Now;

        await _abilityActivationTypeService.Update(abilityActivationType);

        UpdateAbilityActivationTypeResponse mappedResponse = _mapper.Map<UpdateAbilityActivationTypeResponse>(abilityActivationType);
        return mappedResponse;
    }
}

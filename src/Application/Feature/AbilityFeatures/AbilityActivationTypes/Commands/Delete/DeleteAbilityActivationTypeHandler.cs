using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Service.AbilityServices.AbilityActivationTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Delete;

public class DeleteAbilityActivationTypeHandler : IRequestHandler<DeleteAbilityActivationTypeRequest, DeleteAbilityActivationTypeResponse>
{
    private readonly IAbilityActivationTypeService _abilityActivationTypeService;
    private readonly AbilityActivationTypeBusinessRules _abilityActivationTypeBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilityActivationTypeHandler(IAbilityActivationTypeService abilityActivationTypeService, AbilityActivationTypeBusinessRules abilityActivationTypeBusinessRules, IMapper mapper)
    {
        _abilityActivationTypeService = abilityActivationTypeService;
        _abilityActivationTypeBusinessRules = abilityActivationTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilityActivationTypeResponse> Handle(DeleteAbilityActivationTypeRequest request, CancellationToken cancellationToken)
    {
        await _abilityActivationTypeBusinessRules.IdShouldBeExist(request.DeleteAbilityActivationTypeDto.Id);

        AbilityActivationType abilityActivationType = await _abilityActivationTypeService.GetById(request.DeleteAbilityActivationTypeDto.Id);
        abilityActivationType.IsDeleted = true;
        abilityActivationType.Status = false;
        abilityActivationType.DeletedDate = DateTime.Now;

        await _abilityActivationTypeService.Delete(abilityActivationType);

        DeleteAbilityActivationTypeResponse mappedResponse = _mapper.Map<DeleteAbilityActivationTypeResponse>(abilityActivationType);
        return mappedResponse;
    }
}

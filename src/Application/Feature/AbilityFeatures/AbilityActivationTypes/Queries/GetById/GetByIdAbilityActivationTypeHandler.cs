using Application.Feature.AbilityFeatures.AbilityActivationTypes.Rules;
using Application.Service.AbilityServices.AbilityActivationTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Queries.GetById;

public class GetByIdAbilityActivationTypeHandler : IRequestHandler<GetByIdAbilityActivationTypeRequest, GetByIdAbilityActivationTypeResponse>
{
    private readonly IAbilityActivationTypeService _abilityActivationTypeService;
    private readonly AbilityActivationTypeBusinessRules _abilityActivationTypeBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdAbilityActivationTypeHandler(IAbilityActivationTypeService abilityActivationTypeService, AbilityActivationTypeBusinessRules abilityActivationTypeBusinessRules, IMapper mapper)
    {
        _abilityActivationTypeService = abilityActivationTypeService;
        _abilityActivationTypeBusinessRules = abilityActivationTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetByIdAbilityActivationTypeResponse> Handle(GetByIdAbilityActivationTypeRequest request, CancellationToken cancellationToken)
    {
        // Check the existence of the specified ID; it should comply with business rules.
        await _abilityActivationTypeBusinessRules.IdShouldBeExist(request.GetByIdAbilityActivationTypeDto.Id);

        // Retrieve the AbilityActivationType associated with the provided ID from the service.
        AbilityActivationType abilityActivationType = await _abilityActivationTypeService.GetById(request.GetByIdAbilityActivationTypeDto.Id);

        // Map the retrieved AbilityActivationType to the response DTO.
        GetByIdAbilityActivationTypeResponse mappedResponse = _mapper.Map<GetByIdAbilityActivationTypeResponse>(abilityActivationType);

        // Return the mapped response.
        return mappedResponse;

    }
}

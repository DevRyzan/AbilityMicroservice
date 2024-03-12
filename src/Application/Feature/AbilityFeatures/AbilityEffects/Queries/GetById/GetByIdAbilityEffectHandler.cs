using Application.Feature.AbilityFeatures.AbilityEffects.Rules;
using Application.Service.AbilityServices.AbilityEffectService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityEffects.Queries.GetById;

public class GetByIdAbilityEffectHandler : IRequestHandler<GetByIdAbilityEffectRequest, GetByIdAbilityEffectResponse>
{
    private readonly IAbilityEffectService _abilityEffectService;
    private readonly AbilityEffectBusinessRules _abilityEffectBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdAbilityEffectHandler(IAbilityEffectService abilityEffectService, AbilityEffectBusinessRules abilityEffectBusinessRules, IMapper mapper)
    {
        _abilityEffectService = abilityEffectService;
        _abilityEffectBusinessRules = abilityEffectBusinessRules;
        _mapper = mapper;
    }


    public async Task<GetByIdAbilityEffectResponse> Handle(GetByIdAbilityEffectRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the provided ID exists before retrieving the AbilityEffect.
        await _abilityEffectBusinessRules.IdShouldBeExist(request.GetByIdAbilityEffectDto.Id);

        // Retrieve the AbilityEffect entity by ID.
        AbilityEffect abilityEffect = await _abilityEffectService.GetById(request.GetByIdAbilityEffectDto.Id);

        // Map the retrieved AbilityEffect to the response DTO.
        GetByIdAbilityEffectResponse mappedResponse = _mapper.Map<GetByIdAbilityEffectResponse>(abilityEffect);

        // Return the mapped response.
        return mappedResponse;
    }
}

using Application.Feature.AbilityFeatures.AbilityEffectStats.Rules;
using Application.Service.AbilityServices.AbilityEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.Update;

public class UpdateAbilityEffectStatHandler : IRequestHandler<UpdateAbilityEffectStatRequest, UpdateAbilityEffectStatResponse>
{
    private readonly IAbilityEffectStatService _abilityEffectStatService;
    private readonly AbilityEffectStatBusinessRules _abilityEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilityEffectStatHandler(IAbilityEffectStatService abilityEffectStatService, AbilityEffectStatBusinessRules abilityEffectStatBusinessRules, IMapper mapper)
    {
        _abilityEffectStatService = abilityEffectStatService;
        _abilityEffectStatBusinessRules = abilityEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilityEffectStatResponse> Handle(UpdateAbilityEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Check if the ID exists using business rules.
        await _abilityEffectStatBusinessRules.IdShouldBeExist(request.UpdateAbilityEffectStatDto.Id);

        // Get the AbilityEffectStat entity by ID.
        AbilityEffectStat abilityEffectStat = await _abilityEffectStatService.GetById(request.UpdateAbilityEffectStatDto.Id);

        // Map properties from the DTO to the entity.
        _mapper.Map(request.UpdateAbilityEffectStatDto, abilityEffectStat);

        // Update additional properties.
        abilityEffectStat.UpdatedDate = DateTime.Now;

        // Update the AbilityEffectStat entity in the database.
        await _abilityEffectStatService.Update(abilityEffectStat);

        // Map the updated AbilityEffectStat entity to the response DTO.
        UpdateAbilityEffectStatResponse mappedResponse = _mapper.Map<UpdateAbilityEffectStatResponse>(abilityEffectStat);

        // Return the mapped response.
        return mappedResponse;

    }
}

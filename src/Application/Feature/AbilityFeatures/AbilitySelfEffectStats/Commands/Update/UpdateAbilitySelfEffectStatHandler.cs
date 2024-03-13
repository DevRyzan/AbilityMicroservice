using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Rules;
using Application.Service.AbilityServices.AbilitySelfEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.Update;

public class UpdateAbilitySelfEffectStatHandler : IRequestHandler<UpdateAbilitySelfEffectStatRequest, UpdateAbilitySelfEffectStatResponse>
{
    private readonly IAbilitySelfEffectStatService _abilitySelfEffectStatService;
    private readonly AbilitySelfEffectStatBusinessRules _abilitySelfEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public UpdateAbilitySelfEffectStatHandler(IAbilitySelfEffectStatService abilitySelfEffectStatService, AbilitySelfEffectStatBusinessRules abilitySelfEffectStatBusinessRules, IMapper mapper)
    {
        _abilitySelfEffectStatService = abilitySelfEffectStatService;
        _abilitySelfEffectStatBusinessRules = abilitySelfEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateAbilitySelfEffectStatResponse> Handle(UpdateAbilitySelfEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the provided ID exists before attempting the update
        await _abilitySelfEffectStatBusinessRules.IdShouldBeExist(request.UpdateAbilitySelfEffectStatDto.Id);

        // Retrieve the AbilitySelfEffectStat entity from the service by ID
        AbilitySelfEffectStat abilitySelfEffectStat = await _abilitySelfEffectStatService.GetById(request.UpdateAbilitySelfEffectStatDto.Id);

        // Map the properties from the DTO to the entity
        _mapper.Map(request.UpdateAbilitySelfEffectStatDto, abilitySelfEffectStat);

        // Update the timestamp to reflect the modification
        abilitySelfEffectStat.UpdatedDate = DateTime.Now;

        // Update the entity in the database
        await _abilitySelfEffectStatService.Update(abilitySelfEffectStat);

        // Map the updated entity to the corresponding response DTO
        UpdateAbilitySelfEffectStatResponse mappedResponse = _mapper.Map<UpdateAbilitySelfEffectStatResponse>(abilitySelfEffectStat);

        // Return the mapped response
        return mappedResponse;

    }
}

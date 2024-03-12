using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Rules;
using Application.Service.AbilityServices.AbilitySelfEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.ChangeStatus;

public class ChangeStatusAbilitySelfEffectStatHandler : IRequestHandler<ChangeStatusAbilitySelfEffectStatRequest, ChangeStatusAbilitySelfEffectStatResponse>
{
    private readonly IAbilitySelfEffectStatService _abilitySelfEffectStatService;
    private readonly AbilitySelfEffectStatBusinessRules _abilitySelfEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusAbilitySelfEffectStatHandler(IAbilitySelfEffectStatService abilitySelfEffectStatService, AbilitySelfEffectStatBusinessRules abilitySelfEffectStatBusinessRules, IMapper mapper)
    {
        _abilitySelfEffectStatService = abilitySelfEffectStatService;
        _abilitySelfEffectStatBusinessRules = abilitySelfEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusAbilitySelfEffectStatResponse> Handle(ChangeStatusAbilitySelfEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the specified ID exists before proceeding with the status change
        await _abilitySelfEffectStatBusinessRules.IdShouldBeExist(request.ChangeStatusAbilitySelfEffectStatDto.Id);

        // Retrieve the AbilitySelfEffectStat by the provided ID
        AbilitySelfEffectStat abilitySelfEffectStat = await _abilitySelfEffectStatService.GetById(request.ChangeStatusAbilitySelfEffectStatDto.Id);

        // Toggle the status of the AbilitySelfEffectStat
        abilitySelfEffectStat.Status = abilitySelfEffectStat.Status == true ? false : true;

        // Update the 'UpdatedDate' to the current date and time
        abilitySelfEffectStat.UpdatedDate = DateTime.Now;

        // Update the AbilitySelfEffectStat in the database
        await _abilitySelfEffectStatService.Update(abilitySelfEffectStat);

        // Map the updated AbilitySelfEffectStat to the corresponding response DTO
        ChangeStatusAbilitySelfEffectStatResponse mappedResponse = _mapper.Map<ChangeStatusAbilitySelfEffectStatResponse>(abilitySelfEffectStat);

        // Return the mapped response
        return mappedResponse;

    }
}

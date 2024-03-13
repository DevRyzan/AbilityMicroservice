using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Rules;
using Application.Service.AbilityServices.AbilitySelfEffectStatService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.Delete;

public class DeleteAbilitySelfEffectStatHandler : IRequestHandler<DeleteAbilitySelfEffectStatRequest, DeleteAbilitySelfEffectStatResponse>
{
    private readonly IAbilitySelfEffectStatService _abilitySelfEffectStatService;
    private readonly AbilitySelfEffectStatBusinessRules _abilitySelfEffectStatBusinessRules;
    private readonly IMapper _mapper;

    public DeleteAbilitySelfEffectStatHandler(IAbilitySelfEffectStatService abilitySelfEffectStatService, AbilitySelfEffectStatBusinessRules abilitySelfEffectStatBusinessRules, IMapper mapper)
    {
        _abilitySelfEffectStatService = abilitySelfEffectStatService;
        _abilitySelfEffectStatBusinessRules = abilitySelfEffectStatBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteAbilitySelfEffectStatResponse> Handle(DeleteAbilitySelfEffectStatRequest request, CancellationToken cancellationToken)
    {
        // Ensure that the provided ID exists before proceeding with deletion
        await _abilitySelfEffectStatBusinessRules.IdShouldBeExist(request.DeleteAbilitySelfEffectStatDto.Id);

        // Retrieve the AbilitySelfEffectStat entity from the service by ID
        AbilitySelfEffectStat abilitySelfEffectStat = await _abilitySelfEffectStatService.GetById(request.DeleteAbilitySelfEffectStatDto.Id);

        // Set IsDeleted to true, change status to false, and mark the deletion date
        abilitySelfEffectStat.IsDeleted = true;
        abilitySelfEffectStat.Status = false;
        abilitySelfEffectStat.DeletedDate = DateTime.Now;

        // Perform the deletion in the database
        await _abilitySelfEffectStatService.Delete(abilitySelfEffectStat);

        // Map the deleted entity to the corresponding response DTO
        DeleteAbilitySelfEffectStatResponse mappedResponse = _mapper.Map<DeleteAbilitySelfEffectStatResponse>(abilitySelfEffectStat);

        // Return the mapped response
        return mappedResponse;

    }
}

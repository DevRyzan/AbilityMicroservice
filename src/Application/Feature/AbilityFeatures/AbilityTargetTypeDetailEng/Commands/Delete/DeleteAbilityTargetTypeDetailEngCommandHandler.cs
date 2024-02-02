using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeDetailEngService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Commands.Delete;

public class DeleteAbilityTargetTypeDetailEngCommandHandler : IRequestHandler<DeleteAbilityTargetTypeDetailEngCommandRequest, DeleteAbilityTargetTypeDetailEngCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAbilityTargetTypeDetailEngService _abilityTargetTypeDetailEngService;
    private readonly AbilityTargetTypeDetailEngBusinessRules _abilityTargetTypeDetailEngBusinessRules;

    public DeleteAbilityTargetTypeDetailEngCommandHandler(IMapper mapper, IAbilityTargetTypeDetailEngService abilityTargetTypeDetailEngService, AbilityTargetTypeDetailEngBusinessRules abilityTargetTypeDetailEngBusinessRules)
    {
        _mapper = mapper;
        _abilityTargetTypeDetailEngService = abilityTargetTypeDetailEngService;
        _abilityTargetTypeDetailEngBusinessRules = abilityTargetTypeDetailEngBusinessRules;
    }

    public async Task<DeleteAbilityTargetTypeDetailEngCommandResponse> Handle(DeleteAbilityTargetTypeDetailEngCommandRequest request, CancellationToken cancellationToken)
    {
        // Check if the specified ability target type detail (English) ID exists, applying business rules
        await _abilityTargetTypeDetailEngBusinessRules.IdShouldBeExist(id: request.DeleteAbilityTargetTypeDetailEngDto.Id);

        // Retrieve an AbilityTargetTypeDetailEng using the specified ID
        Domain.Abilities.AbilityTargetTypeDetailEng abilityTargetTypeDetailEng = await _abilityTargetTypeDetailEngService.GetById(id: request.DeleteAbilityTargetTypeDetailEngDto.Id);

        // Update the properties of the AbilityTargetTypeDetailEng to mark it as deleted
        abilityTargetTypeDetailEng.Status = false;
        abilityTargetTypeDetailEng.IsDeleted = true;
        abilityTargetTypeDetailEng.DeletedDate = DateTime.Now;

        // Call the Delete method of _abilityTargetTypeDetailEngService to delete the AbilityTargetTypeDetailEng
        await _abilityTargetTypeDetailEngService.Delete(abilityTargetTypeDetailEng);

        // Map the deleted AbilityTargetTypeDetailEng to a DeleteAbilityTargetTypeDetailEngCommandResponse using the mapper
        DeleteAbilityTargetTypeDetailEngCommandResponse mappedResponse = _mapper.Map<DeleteAbilityTargetTypeDetailEngCommandResponse>(abilityTargetTypeDetailEng);

        // Return the mapped response
        return mappedResponse;

    }
}

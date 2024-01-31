using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Rules;
using Application.Service.AbilityServices.AbilityLevelDetailEngService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Commands.Delete;

public class DeleteAbilityLevelDetailEngCommandHandler : IRequestHandler<DeleteAbilityLevelDetailEngCommandRequest, DeleteAbilityLevelDetailEngCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAbilityLevelDetailEngService _abilityLevelDetailEngService;
    private readonly AbilityLevelDetailEngBusinessRules _abilityLevelDetailEngBusinessRules;

    public DeleteAbilityLevelDetailEngCommandHandler(IMapper mapper, IAbilityLevelDetailEngService abilityLevelDetailEngService, AbilityLevelDetailEngBusinessRules abilityLevelDetailEngBusinessRules)
    {
        _mapper = mapper;
        _abilityLevelDetailEngService = abilityLevelDetailEngService;
        _abilityLevelDetailEngBusinessRules = abilityLevelDetailEngBusinessRules;
    }

    public async Task<DeleteAbilityLevelDetailEngCommandResponse> Handle(DeleteAbilityLevelDetailEngCommandRequest request, CancellationToken cancellationToken)
    {
        await _abilityLevelDetailEngBusinessRules.IdShouldBeExist(id: request.DeleteAbilityLevelDetailEngDto.Id);

        Domain.Abilities.AbilityLevelDetailEng abilityLevelDetailEng = await _abilityLevelDetailEngService.GetById(id: request.DeleteAbilityLevelDetailEngDto.Id);

        abilityLevelDetailEng.Status = false;
        abilityLevelDetailEng.IsDeleted = true;
        abilityLevelDetailEng.DeletedDate = DateTime.Now;

        await _abilityLevelDetailEngService.Update(abilityLevelDetailEng);

        DeleteAbilityLevelDetailEngCommandResponse mappedResponse = _mapper.Map<DeleteAbilityLevelDetailEngCommandResponse>(abilityLevelDetailEng);

        return mappedResponse;  

    }
}

using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Rules;
using Application.Service.AbilityServices.AbilityLevelDetailEngService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Commands.Update;

public class UpdateAbilityLevelDetailEngCommandHandler : IRequestHandler<UpdateAbilityLevelDetailEngCommandRequest, UpdateAbilityLevelDetailEngCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAbilityLevelDetailEngService _abilityLevelDetailEngService;
    private readonly AbilityLevelDetailEngBusinessRules _abilityLevelDetailEngBusinessRules;

    public UpdateAbilityLevelDetailEngCommandHandler(IMapper mapper, IAbilityLevelDetailEngService abilityLevelDetailEngService, AbilityLevelDetailEngBusinessRules abilityLevelDetailEngBusinessRules)
    {
        _mapper = mapper;
        _abilityLevelDetailEngService = abilityLevelDetailEngService;
        _abilityLevelDetailEngBusinessRules = abilityLevelDetailEngBusinessRules;
    }

    public async Task<UpdateAbilityLevelDetailEngCommandResponse> Handle(UpdateAbilityLevelDetailEngCommandRequest request, CancellationToken cancellationToken)
    {

        await _abilityLevelDetailEngBusinessRules.IdShouldBeExist(id: request.UpdateAbilityLevelDetailEngDto.Id);
        await _abilityLevelDetailEngBusinessRules.AbilityLevelIdAlreadyHaveDetail(abilityLevelId: request.UpdateAbilityLevelDetailEngDto.AbilityLevelId,Id:request.UpdateAbilityLevelDetailEngDto.Id);
        await _abilityLevelDetailEngBusinessRules.AbilityLevelShouldBeExist(request.UpdateAbilityLevelDetailEngDto.AbilityLevelId);

        Domain.Abilities.AbilityLevelDetailEng abilityLevelDetailEng = await _abilityLevelDetailEngService.GetById(id: request.UpdateAbilityLevelDetailEngDto.Id);

        abilityLevelDetailEng.AbilityLevelId = request.UpdateAbilityLevelDetailEngDto.AbilityLevelId;
        abilityLevelDetailEng.Description = request.UpdateAbilityLevelDetailEngDto.Description;
        abilityLevelDetailEng.UpdatedDate = DateTime.Now;

        await _abilityLevelDetailEngService.Update(abilityLevelDetailEng);

        UpdateAbilityLevelDetailEngCommandResponse mappedResponse = _mapper.Map<UpdateAbilityLevelDetailEngCommandResponse>(abilityLevelDetailEng);

        return mappedResponse;

    }
}

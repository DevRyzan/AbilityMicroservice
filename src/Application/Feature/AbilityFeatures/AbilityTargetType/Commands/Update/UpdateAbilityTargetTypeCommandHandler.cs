using Application.Feature.AbilityFeatures.AbilityTargetType.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Update;

public class UpdateAbilityTargetTypeCommandHandler : IRequestHandler<UpdateAbilityTargetTypeCommandRequest, UpdateAbilityTargetTypeCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly AbilityTargetTypeBusinessRules _abilityTargetTypeBusinessRules;
    private readonly IAbilityTargetTypeService _abilityTargetTypeService;

    public UpdateAbilityTargetTypeCommandHandler(IMapper mapper, AbilityTargetTypeBusinessRules abilityTargetTypeBusinessRules, IAbilityTargetTypeService abilityTargetTypeService)
    {
        _mapper = mapper;
        _abilityTargetTypeBusinessRules = abilityTargetTypeBusinessRules;
        _abilityTargetTypeService = abilityTargetTypeService;
    }

    public async Task<UpdateAbilityTargetTypeCommandResponse> Handle(UpdateAbilityTargetTypeCommandRequest request, CancellationToken cancellationToken)
    {
        //await _abilityTargetTypeBusinessRules.AbilityShouldBeExist(abilityId: request.UpdateAbilityTargetTypeDto.AbilityId);

        //// Check if the specified ability target type ID exists, applying business rules
        //await _abilityTargetTypeBusinessRules.IdShouldBeExist(id: request.UpdateAbilityTargetTypeDto.Id);

        //// Check if the specified ability ID is available for updating the AbilityTargetType, applying business rules
        //await _abilityTargetTypeBusinessRules.AbilityShouldBeAvailableForUpdate(abilityId: request.UpdateAbilityTargetTypeDto.AbilityId, Id: request.UpdateAbilityTargetTypeDto.Id);

        //// Retrieve an AbilityTargetType using the specified ID
        //Domain.Abilities.AbilityTargetType abilityTargetType = await _abilityTargetTypeService.GetById(id: request.UpdateAbilityTargetTypeDto.Id);

        //// Update properties of the AbilityTargetType with data from the request DTO
        //abilityTargetType.AbilityId = request.UpdateAbilityTargetTypeDto.AbilityId;
        //abilityTargetType.IsSingleTarget = request.UpdateAbilityTargetTypeDto.IsSingleTarget;
        //abilityTargetType.IsAreaTarget = request.UpdateAbilityTargetTypeDto.IsAreaTarget;
        //abilityTargetType.Radius = request.UpdateAbilityTargetTypeDto.Radius;
        //abilityTargetType.IconUrl = request.UpdateAbilityTargetTypeDto.IconUrl;

        //// Call the Update method of _abilityTargetTypeService to persist the changes
        //await _abilityTargetTypeService.Update(abilityTargetType);

        //// Map the updated AbilityTargetType to an UpdateAbilityTargetTypeCommandResponse using the mapper
        //UpdateAbilityTargetTypeCommandResponse mappedResponse = _mapper.Map<UpdateAbilityTargetTypeCommandResponse>(abilityTargetType);

        //// Return the mapped response
        //return mappedResponse;

        throw new NotImplementedException();

    }
}

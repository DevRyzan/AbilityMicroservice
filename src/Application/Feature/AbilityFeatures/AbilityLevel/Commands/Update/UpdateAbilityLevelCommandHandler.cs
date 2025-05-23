﻿using Application.Feature.AbilityFeatures.AbilityLevel.Rules;
using Application.Service.AbilityServices.AbilityLevelService;
using AutoMapper;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Commands.Update;

public class UpdateAbilityLevelCommandHandler : IRequestHandler<UpdateAbilityLevelCommandRequest, UpdateAbilityLevelCommandResponse>
{
    private readonly IAbilityLevelService _abilityLevelService;
    private readonly IMapper _mapper;
    private readonly AbilityLevelBusinessRules _abilityLevelBusinessRules;

    public UpdateAbilityLevelCommandHandler(IAbilityLevelService abilityLevelService, IMapper mapper, AbilityLevelBusinessRules abilityLevelBusinessRules)
    {
        _abilityLevelService = abilityLevelService;
        _mapper = mapper;
        _abilityLevelBusinessRules = abilityLevelBusinessRules;
    }

    public async Task<UpdateAbilityLevelCommandResponse> Handle(UpdateAbilityLevelCommandRequest request, CancellationToken cancellationToken)
    {
       // Check if the specified ID exists in the business rules for AbilityLevel update.
        await _abilityLevelBusinessRules.IdShouldBeExist(id: request.UpdateAbilityLevelDto.Id);

        // Retrieve the AbilityLevel using the provided ID.
        Domain.Abilities.AbilityLevel abilityLevel = await _abilityLevelService.GetById(id: request.UpdateAbilityLevelDto.Id);

        _mapper.Map(request.UpdateAbilityLevelDto, abilityLevel);

        // Update the AbilityLevel in the database.
        await _abilityLevelService.Update(abilityLevel);

        // Map the updated AbilityLevel to a response object.
        UpdateAbilityLevelCommandResponse mappedResponse = _mapper.Map<UpdateAbilityLevelCommandResponse>(abilityLevel);

        // Return the mapped response.
        return mappedResponse;

        throw new NotImplementedException();


    }
}

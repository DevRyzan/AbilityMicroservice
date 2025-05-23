﻿
using Application.Feature.AbilityFeatures.AbilityTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.AbilityTypes.Commands.Delete;

public class DeleteAbilityTypeCommandRequest : IRequest<DeleteAbilityTypeCommandResponse>
{
    public DeleteAbilityTypeDto DeleteAbilityTypeDto { get; set; }
}

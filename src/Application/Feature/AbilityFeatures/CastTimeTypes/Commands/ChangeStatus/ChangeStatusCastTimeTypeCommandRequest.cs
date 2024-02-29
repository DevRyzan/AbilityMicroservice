using Application.Feature.AbilityFeatures.CastTimeTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.CastTimeTypes.Commands.ChangeStatus;

public class ChangeStatusCastTimeTypeCommandRequest : IRequest<ChangeStatusCastTimeTypeCommandResponse>
{
    public ChangeStatusCastTimeTypeDto ChangeStatusCastTimeTypeDto { get; set; }
}

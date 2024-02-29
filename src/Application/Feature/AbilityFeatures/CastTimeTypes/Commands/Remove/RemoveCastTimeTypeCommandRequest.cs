using Application.Feature.AbilityFeatures.CastTimeTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Remove;

public class RemoveCastTimeTypeCommandRequest : IRequest<RemoveCastTimeTypeCommandResponse>
{
    public RemoveCastTimeTypeDto RemoveCastTimeTypeDto { get; set; }
}

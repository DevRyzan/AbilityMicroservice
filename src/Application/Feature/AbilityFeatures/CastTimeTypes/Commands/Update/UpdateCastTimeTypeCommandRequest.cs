using Application.Feature.AbilityFeatures.CastTimeTypes.Dtos;
using MediatR;

namespace Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Update;

public class UpdateCastTimeTypeCommandRequest : IRequest<UpdateCastTimeTypeCommandResponse>
{
    public UpdateCastTimeTypeDto UpdateCastTimeTypeDto { get; set; }

}

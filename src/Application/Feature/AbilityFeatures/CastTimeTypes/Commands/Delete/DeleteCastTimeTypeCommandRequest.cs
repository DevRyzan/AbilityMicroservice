using Application.Feature.AbilityFeatures.CastTimeTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Delete;

public class DeleteCastTimeTypeCommandRequest : IRequest<DeleteCastTimeTypeCommandResponse>
{
    public DeleteCastTimeTypeDto DeleteCastTimeTypeDto { get; set; }
}

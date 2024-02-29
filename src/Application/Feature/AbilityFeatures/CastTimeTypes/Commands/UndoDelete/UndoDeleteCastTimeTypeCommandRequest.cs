using Application.Feature.AbilityFeatures.CastTimeTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.CastTimeTypes.Commands.UndoDelete;

public class UndoDeleteCastTimeTypeCommandRequest : IRequest<UndoDeleteCastTimeTypeCommandResponse>
{
    public UndoDeleteCastTimeTypeDto UndoDeleteCastTimeTypeDto { get; set; }
}

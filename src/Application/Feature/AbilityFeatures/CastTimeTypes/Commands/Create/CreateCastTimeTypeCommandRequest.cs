using Application.Feature.AbilityFeatures.CastTimeTypes.Dtos;
using MediatR;


namespace Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Create;

public class CreateCastTimeTypeCommandRequest : IRequest<CreateCastTimeTypeCommandResponse>
{
    public CreateCastTimeTypeDto CreateCastTimeTypeDto { get; set; }
}

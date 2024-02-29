using Application.Feature.AbilityFeatures.CastTimeTypes.Rules;
using Application.Service.AbilityServices.CastTimeTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Remove;

public class RemoveCastTimeTypeCommandHandler : IRequestHandler<RemoveCastTimeTypeCommandRequest, RemoveCastTimeTypeCommandResponse>
{
    private readonly ICastTimeTypeService _castTimeTypeService;
    private readonly CastTimeTypeBusinessRules _castTimeTypeBusinessRules;
    private readonly IMapper _mapper;

    public RemoveCastTimeTypeCommandHandler(ICastTimeTypeService castTimeTypeService, CastTimeTypeBusinessRules castTimeTypeBusinessRules, IMapper mapper)
    {
        _castTimeTypeService = castTimeTypeService;
        _castTimeTypeBusinessRules = castTimeTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<RemoveCastTimeTypeCommandResponse> Handle(RemoveCastTimeTypeCommandRequest request, CancellationToken cancellationToken)
    {
        await _castTimeTypeBusinessRules.IdShouldBeExist(request.RemoveCastTimeTypeDto.Id);

        await _castTimeTypeBusinessRules.RemoveCondition(request.RemoveCastTimeTypeDto.Id);

        CastTimeType castTimeType = await _castTimeTypeService.GetById(request.RemoveCastTimeTypeDto.Id);

        await _castTimeTypeService.Remove(castTimeType);

        RemoveCastTimeTypeCommandResponse mappedResponse = _mapper.Map<RemoveCastTimeTypeCommandResponse>(castTimeType);
        return mappedResponse;

    }
}

using Application.Feature.AbilityFeatures.CastTimeTypes.Rules;
using Application.Service.AbilityServices.CastTimeTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;

namespace Application.Feature.AbilityFeatures.CastTimeTypes.Commands.UndoDelete;

public class UndoDeleteCastTimeTypeCommandHandler : IRequestHandler<UndoDeleteCastTimeTypeCommandRequest, UndoDeleteCastTimeTypeCommandResponse>
{
    private readonly ICastTimeTypeService _castTimeTypeService;
    private readonly CastTimeTypeBusinessRules _castTimeTypeBusinessRules;
    private readonly IMapper _mapper;

    public UndoDeleteCastTimeTypeCommandHandler(ICastTimeTypeService castTimeTypeService, CastTimeTypeBusinessRules castTimeTypeBusinessRules, IMapper mapper)
    {
        _castTimeTypeService = castTimeTypeService;
        _castTimeTypeBusinessRules = castTimeTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UndoDeleteCastTimeTypeCommandResponse> Handle(UndoDeleteCastTimeTypeCommandRequest request, CancellationToken cancellationToken)
    {
        await _castTimeTypeBusinessRules.IdShouldBeExist(request.UndoDeleteCastTimeTypeDto.Id);

        CastTimeType castTimeType = await _castTimeTypeService.GetById(request.UndoDeleteCastTimeTypeDto.Id);

        castTimeType.IsDeleted = false;
        castTimeType.UpdatedDate = DateTime.Now;

        await _castTimeTypeService.Update(castTimeType);

        UndoDeleteCastTimeTypeCommandResponse mappedResponse = _mapper.Map<UndoDeleteCastTimeTypeCommandResponse>(castTimeType);
        return mappedResponse;
    }
}

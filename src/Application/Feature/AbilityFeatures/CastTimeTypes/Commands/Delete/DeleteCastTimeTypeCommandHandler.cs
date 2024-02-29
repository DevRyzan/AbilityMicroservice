using Application.Feature.AbilityFeatures.CastTimeTypes.Rules;
using Application.Service.AbilityServices.CastTimeTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Delete;

public class DeleteCastTimeTypeCommandHandler : IRequestHandler<DeleteCastTimeTypeCommandRequest, DeleteCastTimeTypeCommandResponse>
{
    private readonly ICastTimeTypeService _castTimeTypeService;
    private readonly CastTimeTypeBusinessRules _castTimeTypeBusinessRules;
    private readonly IMapper _mapper;

    public DeleteCastTimeTypeCommandHandler(ICastTimeTypeService castTimeTypeService, CastTimeTypeBusinessRules castTimeTypeBusinessRules, IMapper mapper)
    {
        _castTimeTypeService = castTimeTypeService;
        _castTimeTypeBusinessRules = castTimeTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<DeleteCastTimeTypeCommandResponse> Handle(DeleteCastTimeTypeCommandRequest request, CancellationToken cancellationToken)
    {
        await _castTimeTypeBusinessRules.IdShouldBeExist(request.DeleteCastTimeTypeDto.Id);

        CastTimeType castTimeType = await _castTimeTypeService.GetById(request.DeleteCastTimeTypeDto.Id);

        castTimeType.IsDeleted = true;
        castTimeType.Status = false;
        castTimeType.DeletedDate = DateTime.Now;

        await _castTimeTypeService.Delete(castTimeType);

        DeleteCastTimeTypeCommandResponse mappedResponse = _mapper.Map<DeleteCastTimeTypeCommandResponse>(castTimeType);

        return mappedResponse;
    }
}

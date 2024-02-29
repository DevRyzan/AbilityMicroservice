using Application.Feature.AbilityFeatures.CastTimeTypes.Rules;
using Application.Service.AbilityServices.CastTimeTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Update;

public class UpdateCastTimeTypeCommandHandler : IRequestHandler<UpdateCastTimeTypeCommandRequest, UpdateCastTimeTypeCommandResponse>
{
    private readonly ICastTimeTypeService _castTimeTypeService;
    private readonly CastTimeTypeBusinessRules _castTimeTypeBusinessRules;
    private readonly IMapper _mapper;

    public UpdateCastTimeTypeCommandHandler(ICastTimeTypeService castTimeTypeService, CastTimeTypeBusinessRules castTimeTypeBusinessRules, IMapper mapper)
    {
        _castTimeTypeService = castTimeTypeService;
        _castTimeTypeBusinessRules = castTimeTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<UpdateCastTimeTypeCommandResponse> Handle(UpdateCastTimeTypeCommandRequest request, CancellationToken cancellationToken)
    {
        await _castTimeTypeBusinessRules.IdShouldBeExist(request.UpdateCastTimeTypeDto.Id);

        CastTimeType castTimeType = await _castTimeTypeService.GetById(request.UpdateCastTimeTypeDto.Id);
        castTimeType.Name = request.UpdateCastTimeTypeDto.Name;
        castTimeType.Description = request.UpdateCastTimeTypeDto.Description;
        castTimeType.UpdatedDate = DateTime.Now;

        await _castTimeTypeService.Update(castTimeType);

        UpdateCastTimeTypeCommandResponse mappedResponse = _mapper.Map<UpdateCastTimeTypeCommandResponse>(castTimeType);

        return mappedResponse;

    }
}

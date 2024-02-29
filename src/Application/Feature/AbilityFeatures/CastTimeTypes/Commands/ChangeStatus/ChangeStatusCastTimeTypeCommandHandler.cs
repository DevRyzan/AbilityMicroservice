using Application.Feature.AbilityFeatures.CastTimeTypes.Rules;
using Application.Service.AbilityServices.CastTimeTypeService;
using AutoMapper;
using Domain.Abilities;
using MediatR;


namespace Application.Feature.AbilityFeatures.CastTimeTypes.Commands.ChangeStatus;

public class ChangeStatusCastTimeTypeCommandHandler : IRequestHandler<ChangeStatusCastTimeTypeCommandRequest, ChangeStatusCastTimeTypeCommandResponse>
{
    private readonly ICastTimeTypeService _castTimeTypeService;
    private readonly CastTimeTypeBusinessRules _castTimeTypeBusinessRules;
    private readonly IMapper _mapper;

    public ChangeStatusCastTimeTypeCommandHandler(ICastTimeTypeService castTimeTypeService, CastTimeTypeBusinessRules castTimeTypeBusinessRules, IMapper mapper)
    {
        _castTimeTypeService = castTimeTypeService;
        _castTimeTypeBusinessRules = castTimeTypeBusinessRules;
        _mapper = mapper;
    }

    public async Task<ChangeStatusCastTimeTypeCommandResponse> Handle(ChangeStatusCastTimeTypeCommandRequest request, CancellationToken cancellationToken)
    {
        await _castTimeTypeBusinessRules.IdShouldBeExist(request.ChangeStatusCastTimeTypeDto.Id);

        CastTimeType castTimeType = await _castTimeTypeService.GetById(request.ChangeStatusCastTimeTypeDto.Id);

        castTimeType.Status = castTimeType.Status == true ? false : true;
        castTimeType.UpdatedDate = DateTime.Now;

        await _castTimeTypeService.Update(castTimeType);

        ChangeStatusCastTimeTypeCommandResponse mappedResponse = _mapper.Map<ChangeStatusCastTimeTypeCommandResponse>(castTimeType);

        return mappedResponse;

    }
}

using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Create;
using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Delete;
using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Remove;
using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Update;
using Application.Feature.AbilityFeatures.CastTimeTypes.Dtos;
using Application.Feature.AbilityFeatures.CastTimeTypes.Queries.GetById;
using Application.Feature.AbilityFeatures.CastTimeTypes.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.CastTimeTypes.Queries.GetListByInActive;
using AutoMapper;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.CastTimeTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CastTimeType, CreateCastTimeTypeDto>().ReverseMap();
        CreateMap<CastTimeType, CreateCastTimeTypeCommandResponse>().ReverseMap();

        CreateMap<CastTimeType, UpdateCastTimeTypeDto>().ReverseMap();
        CreateMap<CastTimeType, UpdateCastTimeTypeCommandResponse>().ReverseMap();

        CreateMap<CastTimeType, ChangeStatusCastTimeTypeCommandResponse>().ReverseMap();
        CreateMap<CastTimeType, DeleteCastTimeTypeCommandResponse>().ReverseMap();
        CreateMap<CastTimeType, RemoveCastTimeTypeCommandResponse>().ReverseMap();
        CreateMap<CastTimeType, UndoDeleteCastTimeTypeCommandResponse>().ReverseMap();


        CreateMap<CastTimeType, GetByIdCastTimeTypeQueryResponse>().ReverseMap();
        CreateMap<CastTimeType, GetListByActiveCastTimeTypeResponse>().ReverseMap();
        CreateMap<CastTimeType, GetListByInActiveCastTimeTypeResponse>().ReverseMap();

    }
}

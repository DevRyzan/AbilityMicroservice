using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Create;
using Application.Feature.AbilityFeatures.CastTimeTypes.Dtos;
using AutoMapper;
using Domain.Abilities;

namespace Application.Feature.AbilityFeatures.CastTimeTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CastTimeType, CreateCastTimeTypeDto>().ReverseMap();
        CreateMap<CastTimeType, CreateCastTimeTypeCommandResponse>().ReverseMap();



    }
}

using Application.Feature.AbilityFeatures.AbilityLevel.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityLevel.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityLevel.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityLevel.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityLevel.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityLevel.Dto;
using Application.Feature.AbilityFeatures.AbilityLevel.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityLevel.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityLevel.Queries.GetListByInActive;
using AutoMapper;

namespace Application.Feature.AbilityFeatures.AbilityLevel.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.Abilities.AbilityLevel, ChangeStatusAbilityLevelCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityLevel, CreateAbilityLevelDto>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityLevel, CreateAbilityLevelCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityLevel, DeleteAbilityLevelCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityLevel, RemoveAbilityLevelCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityLevel, UpdateAbilityLevelCommandResponse>().ReverseMap();

        CreateMap<UpdateAbilityLevelDto, Domain.Abilities.AbilityLevel>();

        CreateMap<Domain.Abilities.AbilityLevel, GetByIdAbilityLevelCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityLevel, GetListByActiveAbilityLevelCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityLevel, GetListByInActiveAbilityLevelCommandResponse>().ReverseMap();
    }
}

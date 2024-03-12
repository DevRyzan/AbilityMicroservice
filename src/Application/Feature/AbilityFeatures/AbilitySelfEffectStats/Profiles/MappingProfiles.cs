using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.Create;
using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Commands.Update;
using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Dtos;
using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Queries.GetListByInActive;
using AutoMapper;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AbilitySelfEffectStat, CreateAbilitySelfEffectStatDto>().ReverseMap();
        CreateMap<AbilitySelfEffectStat, CreateAbilitySelfEffectStatResponse>().ReverseMap();

        CreateMap<AbilitySelfEffectStat, ChangeStatusAbilitySelfEffectStatResponse>().ReverseMap();
        CreateMap<AbilitySelfEffectStat, DeleteAbilitySelfEffectStatResponse>().ReverseMap();
        CreateMap<AbilitySelfEffectStat, RemoveAbilitySelfEffectStatResponse>().ReverseMap();
        CreateMap<AbilitySelfEffectStat, UndoDeleteAbilitySelfEffectStatResponse>().ReverseMap();

        CreateMap<AbilitySelfEffectStat, UpdateAbilitySelfEffectStatDto>().ReverseMap();
        CreateMap<AbilitySelfEffectStat, UpdateAbilitySelfEffectStatResponse>().ReverseMap();

        CreateMap<AbilitySelfEffectStat, GetByIdAbilitySelfEffectStatResponse>().ReverseMap();
        CreateMap<AbilitySelfEffectStat, GetListByActiveAbilitySelfEffectStatResponse>().ReverseMap();
        CreateMap<AbilitySelfEffectStat, GetListByInActiveAbilitySelfEffectStatResponse>().ReverseMap();

    }
}

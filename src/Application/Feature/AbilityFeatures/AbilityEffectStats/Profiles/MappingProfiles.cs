using Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityEffectStats.Queries.GetListByInActive;
using AutoMapper;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilityEffectStats.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {

        CreateMap<AbilityEffectStat, CreateAbilityEffectStatDto>().ReverseMap();
        CreateMap<AbilityEffectStat, CreateAbilityEffectStatResponse>().ReverseMap();
                  
        CreateMap<AbilityEffectStat, ChangeStatusAbilityEffectStatResponse>().ReverseMap();
        CreateMap<AbilityEffectStat, DeleteAbilityEffectStatResponse>().ReverseMap();
        CreateMap<AbilityEffectStat, RemoveAbilityEffectStatResponse>().ReverseMap();
        CreateMap<AbilityEffectStat, UndoDeleteAbilityEffectStatResponse>().ReverseMap();
                  
        CreateMap<AbilityEffectStat, UpdateAbilityEffectStatDto>().ReverseMap();
        CreateMap<AbilityEffectStat, UpdateAbilityEffectStatResponse>().ReverseMap();


        CreateMap<AbilityEffectStat, GetByIdAbilityEffectStatResponse>().ReverseMap();
        CreateMap<AbilityEffectStat, GetByActiveListAbilityEffectStatResponse>().ReverseMap();
        CreateMap<AbilityEffectStat, GetListByInActiveAbilityEffectStatResponse>().ReverseMap();
    }
}

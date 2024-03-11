using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Dto;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Queries.GetListByInActive;
using AutoMapper;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AbilityEnemyEffectStat, CreateAbilityEnemyEffectStatDto>().ReverseMap();
        CreateMap<AbilityEnemyEffectStat, CreateAbilityEnemyEffectStatResponse>().ReverseMap();

        CreateMap<AbilityEnemyEffectStat, ChangeStatusAbilityEnemyEffectStatResponse>().ReverseMap();
        CreateMap<AbilityEnemyEffectStat, DeleteAbilityEnemyEffectStatResponse>().ReverseMap();
        CreateMap<AbilityEnemyEffectStat, RemoveAbilityEnemyEffectStatResponse>().ReverseMap();
        CreateMap<AbilityEnemyEffectStat, UndoDeleteAbilityEnemyEffectStatResponse>().ReverseMap();

        CreateMap<AbilityEnemyEffectStat, UpdateAbilityEnemyEffectStatDto>().ReverseMap();
        CreateMap<AbilityEnemyEffectStat, UpdateAbilityEnemyEffectStatResponse>().ReverseMap();

        CreateMap<AbilityEnemyEffectStat, GetByIdAbilityEnemyEffectStatResponse>().ReverseMap();
        CreateMap<AbilityEnemyEffectStat, GetListByActiveAbilityEnemyEffectStatResponse>().ReverseMap();
        CreateMap<AbilityEnemyEffectStat, GetListByInActiveAbilityEnemyEffectStatResponse>().ReverseMap();

    }
}

using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Dto;
using AutoMapper;
using Domain.Abilities;



namespace Application.Feature.AbilityFeatures.AbilityAllyEffectStats.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AbilityAllyEffectStat, ChangeStatusAbilityAllyEffectStatResponse>().ReverseMap();

        CreateMap<AbilityAllyEffectStat, CreateAbilityAllyEffectStatDto>().ReverseMap();
        CreateMap<AbilityAllyEffectStat, CreateAbilityAllyEffectStatResponse>().ReverseMap();

        CreateMap<AbilityAllyEffectStat, DeleteAbilityAllyEffectStatResponse>().ReverseMap();
        CreateMap<AbilityAllyEffectStat, RemoveAbilityAllyEffectStatResponse>().ReverseMap();
        CreateMap<AbilityAllyEffectStat, UndoDeleteAbilityAllyEffectStatResponse>().ReverseMap();

        CreateMap<AbilityAllyEffectStat, UpdateAbilityAllyEffectStatDto>().ReverseMap();
        CreateMap<AbilityAllyEffectStat, UpdateAbilityAllyEffectStatResponse>().ReverseMap();

        CreateMap<AbilityAllyEffectStat, UpdateAbilityAllyEffectStatResponse>().ReverseMap();
        CreateMap<AbilityAllyEffectStat, UpdateAbilityAllyEffectStatResponse>().ReverseMap();
        CreateMap<AbilityAllyEffectStat, UpdateAbilityAllyEffectStatResponse>().ReverseMap();

    }
}

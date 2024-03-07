using Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityAttackStats.Dto;
using AutoMapper;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilityAttackStats.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AbilityAttackStat, CreateAbilityAttackStatDto>().ReverseMap();
        CreateMap<AbilityAttackStat, CreateAbilityAttackStatResponse>().ReverseMap();

        CreateMap<AbilityAttackStat, ChangeStatusAbilityAttackStatResponse>().ReverseMap();
        CreateMap<AbilityAttackStat, DeleteAbilityAttackStatResponse>().ReverseMap();
        CreateMap<AbilityAttackStat, RemoveAbilityAttackStatResponse>().ReverseMap();
        CreateMap<AbilityAttackStat, UndoDeleteAbilityAttackStatResponse>().ReverseMap();

        CreateMap<AbilityAttackStat, UpdateAbilityAttackStatDto>().ReverseMap();
        CreateMap<AbilityAttackStat, UpdateAbilityAttackStatResponse>().ReverseMap();




    }
}

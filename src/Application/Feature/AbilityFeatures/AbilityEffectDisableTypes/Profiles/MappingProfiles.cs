using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Dtos;
using AutoMapper;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {

        CreateMap<AbilityEffectDisableType, ChangeStatusAbilityEffectDisableTypeResponse>().ReverseMap();

        CreateMap<AbilityEffectDisableType, CreateAbilityEffectDisableTypeDto>().ReverseMap();
        CreateMap<AbilityEffectDisableType, CreateAbilityEffectDisableTypeResponse>().ReverseMap();

        CreateMap<AbilityEffectDisableType, DeleteAbilityEffectDisableTypeResponse>().ReverseMap();

        CreateMap<AbilityEffectDisableType, RemoveAbilityEffectDisableTypeResponse>().ReverseMap();

        CreateMap<AbilityEffectDisableType, UndoDeleteAbilityEffectDisableTypeResponse>().ReverseMap();

        CreateMap<AbilityEffectDisableType, UpdateAbilityEffectDisableTypeResponse>().ReverseMap();





    }
}

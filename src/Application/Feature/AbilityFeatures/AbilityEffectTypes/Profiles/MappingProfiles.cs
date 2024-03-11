using Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Queries.GetListByInActive;
using AutoMapper;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilityEffectTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AbilityEffectType, CreateAbilityEffectTypeDto>().ReverseMap();
        CreateMap<AbilityEffectType, CreateAbilityEffectTypeResponse>().ReverseMap();

        CreateMap<AbilityEffectType, ChangeStatusAbilityEffectTypeResponse>().ReverseMap();
        CreateMap<AbilityEffectType, DeleteAbilityEffectTypeResponse>().ReverseMap();
        CreateMap<AbilityEffectType, RemoveAbilityEffectTypeResponse>().ReverseMap();
        CreateMap<AbilityEffectType, UpdateAbilityEffectTypeResponse>().ReverseMap();
        CreateMap<AbilityEffectType, UndoDeleteAbilityEffectTypeResponse>().ReverseMap();


        CreateMap<AbilityEffectType, GetByIdAbilityEffectTypeResponse>().ReverseMap();
        CreateMap<AbilityEffectType, GetByActiveListAbilityEffectTypeResponse>().ReverseMap();
        CreateMap<AbilityEffectType, GetByInActiveListAbilityEffectTypeResponse>().ReverseMap();



    }
}

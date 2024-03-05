using Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityDamageTypes.Queries.GetListByInActive;
using AutoMapper;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilityDamageTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AbilityDamageType, ChangeStatusAbilityDamageTypeResponse>().ReverseMap();

        CreateMap<AbilityDamageType, CreateAbilityDamageTypeDto>().ReverseMap();
        CreateMap<AbilityDamageType, CreateAbilityDamageTypeResponse>().ReverseMap();

        CreateMap<AbilityDamageType, DeleteAbilityDamageTypeResponse>().ReverseMap();

        CreateMap<AbilityDamageType, RemoveAbilityDamageTypeResponse>().ReverseMap();

        CreateMap<AbilityDamageType, UndoDeleteAbilityDamageTypeResponse>().ReverseMap();

        CreateMap<AbilityDamageType, UpdateAbilityDamageTypeResponse>().ReverseMap();

        CreateMap<AbilityDamageType, GetByIdAbilityDamageTypeResponse>().ReverseMap();
        CreateMap<AbilityDamageType, GetListByActiveAbilityDamageTypeResponse>().ReverseMap();
        CreateMap<AbilityDamageType, GetListByInActiveAbilityDamageTypeResponse>().ReverseMap();


    }
}

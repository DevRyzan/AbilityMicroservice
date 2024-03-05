using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityEffectDisableTypes.Queries.GetListByInActive;
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

        CreateMap<AbilityEffectDisableType, GetByIdAbilityEffectDisableTypeResponse>().ReverseMap();

        CreateMap<AbilityEffectDisableType, GetListByActiveAbilityEffectDisableTypeResponse>().ReverseMap();
        CreateMap<List<AbilityEffectDisableType>, List<GetListByActiveAbilityEffectDisableTypeResponse>>().ReverseMap();

        CreateMap<AbilityEffectDisableType, GetListByInActiveAbilityEffectDisableTypeResponse>().ReverseMap();
        CreateMap<List<AbilityEffectDisableType>, List<GetListByInActiveAbilityEffectDisableTypeResponse>>().ReverseMap();



    }
}

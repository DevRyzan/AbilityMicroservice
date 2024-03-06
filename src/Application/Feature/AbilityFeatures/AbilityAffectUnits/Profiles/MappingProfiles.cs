using Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Dto;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Queries.GetListByInActive;
using AutoMapper;
using Domain.Abilities;

namespace Application.Feature.AbilityFeatures.AbilityAffectUnits.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AbilityAffectUnit, ChangeStatusAbilityAffectUnitResponse>().ReverseMap();

        CreateMap<AbilityAffectUnit, CreateAbilityAffectUnitDto>().ReverseMap();
        CreateMap<AbilityAffectUnit, CreateAbilityAffectUnitResponse>().ReverseMap();

        CreateMap<AbilityAffectUnit, DeleteAbilityAffectUnitResponse>().ReverseMap();
        CreateMap<AbilityAffectUnit, RemoveAbilityAffectUnitResponse>().ReverseMap();
        CreateMap<AbilityAffectUnit, UndoDeleteAbilityAffectUnitResponse>().ReverseMap();
        CreateMap<AbilityAffectUnit, UpdateAbilityAffectUnitResponse>().ReverseMap();

        CreateMap<AbilityAffectUnit, GetByIdAbilityAffectUnitResponse>().ReverseMap();
        CreateMap<AbilityAffectUnit, GetListByActiveAbilityAffectUnitResponse>().ReverseMap();
        CreateMap<AbilityAffectUnit, GetListByInActiveAbilityAffectUnitResponse>().ReverseMap();


    }
}

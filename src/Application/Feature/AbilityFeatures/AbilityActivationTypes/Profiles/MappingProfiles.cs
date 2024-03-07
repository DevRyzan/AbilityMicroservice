using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Dto;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Queries.GetListByInActive;
using AutoMapper;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AbilityActivationType, ChangeStatusAbilityActivationTypeResponse>().ReverseMap();

        CreateMap<AbilityActivationType, CreateAbilityActivationTypeDto>().ReverseMap();
        CreateMap<AbilityActivationType, CreateAbilityActivationTypeResponse>().ReverseMap();

        CreateMap<AbilityActivationType, DeleteAbilityActivationTypeResponse>().ReverseMap();
        CreateMap<AbilityActivationType, RemoveAbilityActivationTypeResponse>().ReverseMap();
        CreateMap<AbilityActivationType, UndoDeleteAbilityActivationTypeResponse>().ReverseMap();
        CreateMap<AbilityActivationType, UpdateAbilityActivationTypeResponse>().ReverseMap();

        CreateMap<AbilityActivationType, GetByIdAbilityActivationTypeResponse>().ReverseMap();
        CreateMap<AbilityActivationType, GetListByActiveAbilityActivationTypeResponse>().ReverseMap();
        CreateMap<AbilityActivationType, GetListByInActiveAbilityActivationTypeResponse>().ReverseMap();

    }
}

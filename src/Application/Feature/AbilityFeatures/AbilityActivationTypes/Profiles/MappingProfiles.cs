using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityActivationTypes.Dto;
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




    }
}

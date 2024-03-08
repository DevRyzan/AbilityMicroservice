using Application.Feature.AbilityFeatures.AbilityEffects.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityEffects.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityEffects.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityEffects.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityEffects.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityEffects.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityEffects.Dtos;
using AutoMapper;
using Domain.Abilities;


namespace Application.Feature.AbilityFeatures.AbilityEffects.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AbilityEffect, CreateAbilityEffectDto>().ReverseMap();
        CreateMap<AbilityEffect, CreateAbilityEffectResponse>().ReverseMap();

        CreateMap<AbilityEffect, ChangeStatusAbilityEffectResponse>().ReverseMap();
        CreateMap<AbilityEffect, DeleteAbilityEffectResponse>().ReverseMap();
        CreateMap<AbilityEffect, RemoveAbilityEffectResponse>().ReverseMap();
        CreateMap<AbilityEffect, UndoDeleteAbilityEffectResponse>().ReverseMap();

        CreateMap<AbilityEffect, UpdateAbilityEffectDto>().ReverseMap();
        CreateMap<AbilityEffect, UpdateAbilityEffectResponse>().ReverseMap();

        CreateMap<AbilityEffect, UndoDeleteAbilityEffectResponse>().ReverseMap();
        CreateMap<AbilityEffect, UndoDeleteAbilityEffectResponse>().ReverseMap();
        CreateMap<AbilityEffect, UndoDeleteAbilityEffectResponse>().ReverseMap();



    }
}

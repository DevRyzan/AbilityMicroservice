using Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Dtos;
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





    }
}

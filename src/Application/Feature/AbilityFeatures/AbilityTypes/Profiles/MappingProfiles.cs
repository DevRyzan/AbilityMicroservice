using Application.Feature.AbilityFeatures.AbilityTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityTypes.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityTypes.Dtos;
using AutoMapper;
using Domain.Abilities;

namespace Application.Feature.AbilityFeatures.AbilityTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AbilityType, CreateAbilityTypeDto>().ReverseMap();
        CreateMap<AbilityType, CreateAbilityTypeCommandResponse>().ReverseMap();

        CreateMap<AbilityType, ChangeStatusAbilityTypeCommandResponse>().ReverseMap();



    }
}

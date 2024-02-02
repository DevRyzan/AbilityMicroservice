using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityTargetType.Dto;
using Application.Feature.AbilityFeatures.AbilityTargetType.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityTargetType.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityTargetType.Queries.GetListByInActive;
using AutoMapper;

namespace Application.Feature.AbilityFeatures.AbilityTargetType.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.Abilities.AbilityTargetType, ChangeStatusAbilityTargetTypeCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityTargetType, CreateAbilityTargetTypeDto>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityTargetType, CreateAbilityTargetTypeCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityTargetType, DeleteAbilityTargetTypeCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityTargetType, RemoveAbilityTargetTypeCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityTargetType, UpdateAbilityTargetTypeCommandResponse>().ReverseMap();

        CreateMap<Domain.Abilities.AbilityTargetType, GetByIdAbilityTargetTypeCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityTargetType, GetByActiveListAbilityTargetTypeCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityTargetType, GetByInActiveListAbilityTargetTypeCommandResponse>().ReverseMap();
    }
}

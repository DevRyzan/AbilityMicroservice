using Application.Feature.AbilityFeatures.AbilityTypes.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityTypes.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityTypes.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityTypes.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityTypes.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.AbilityTypes.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityTypes.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityTypes.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityTypes.Queries.GetListByInActive;
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

        CreateMap<AbilityType, DeleteAbilityTypeCommandResponse>().ReverseMap();

        CreateMap<AbilityType, RemoveAbilityTypeCommandResponse>().ReverseMap();

        CreateMap<AbilityType, UndoDeleteAbilityTypeCommandResponse>().ReverseMap();

        CreateMap<AbilityType, UpdateAbilityTypeCommandResponse>().ReverseMap();



        CreateMap<AbilityType, GetByIdAbilityTypeQueryResponse>().ReverseMap();
        CreateMap<AbilityType, GetListByActiveAbilityTypeQueryResponse>().ReverseMap();
        CreateMap<AbilityType, GetListByInActiveAbilityTypeQueryResponse>().ReverseMap();



    }
}

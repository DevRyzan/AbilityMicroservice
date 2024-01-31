using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Dto;
using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Queries.GetByAbilityId;
using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Queries.GetListByInActive;
using AutoMapper;

namespace Application.Feature.AbilityFeatures.AbilityLevelDetailEng.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.Abilities.AbilityLevelDetailEng, ChangeStatusAbilityLevelDetailEngCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityLevelDetailEng, CreateAbilityLevelDetailEngCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityLevelDetailEng, CreateAbilityLevelDetailEngDto>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityLevelDetailEng, DeleteAbilityLevelDetailEngCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityLevelDetailEng, RemoveAbilityLevelDetailEngCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityLevelDetailEng, UpdateAbilityLevelDetailEngCommandResponse>().ReverseMap();


        CreateMap<Domain.Abilities.AbilityLevelDetailEng, UpdateAbilityLevelDetailEngCommandResponse>().ReverseMap();

        CreateMap<Domain.Abilities.AbilityLevelDetailEng, GetByIdAbilityLevelDetailEngCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityLevelDetailEng, GetByAbilityIdAbilityLevelDetailEngCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityLevelDetailEng, GetListByActiveAbilityLevelDetailEngCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityLevelDetailEng, GetListByInActiveAbilityLevelDetailEngCommandResponse>().ReverseMap();
    }
}

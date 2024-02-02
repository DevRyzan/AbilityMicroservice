using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Dto;
using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Queries.GetListByInActive;
using AutoMapper;

namespace Application.Feature.AbilityFeatures.AbilityTargetTypeDetailEng.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.Abilities.AbilityTargetTypeDetailEng, ChangeStatusAbilityTargetTypeDetailEngCommandResponse>().ReverseMap();

        CreateMap<Domain.Abilities.AbilityTargetTypeDetailEng, CreateAbilityTargetTypeDetailEngDto>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityTargetTypeDetailEng, CreateAbilityTargetTypeDetailEngCommandResponse>().ReverseMap();


        CreateMap<Domain.Abilities.AbilityTargetTypeDetailEng, DeleteAbilityTargetTypeDetailEngCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityTargetTypeDetailEng, RemoveAbilityTargetTypeDetailEngCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityTargetTypeDetailEng, UpdateAbilityTargetTypeDetailEngCommandResponse>().ReverseMap();

        CreateMap<Domain.Abilities.AbilityTargetTypeDetailEng, GetByIdAbilityTargetTypeDetailEngCommandResponse>().ReverseMap();

        CreateMap<Domain.Abilities.AbilityTargetTypeDetailEng, GetListByActiveAbilityTargetTypeDetailEngCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityTargetTypeDetailEng, GetListByInActiveAbilityTargetTypeDetailEngCommandResponse>().ReverseMap();
    }
}

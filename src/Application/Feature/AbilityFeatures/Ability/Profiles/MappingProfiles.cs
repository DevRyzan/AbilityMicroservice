using Application.Feature.AbilityFeatures.Ability.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.Ability.Commands.Create;
using Application.Feature.AbilityFeatures.Ability.Commands.Delete;
using Application.Feature.AbilityFeatures.Ability.Commands.Remove;
using Application.Feature.AbilityFeatures.Ability.Commands.Update;
using Application.Feature.AbilityFeatures.Ability.Dtos;
using Application.Feature.AbilityFeatures.Ability.Queries.GetById;
using Application.Feature.AbilityFeatures.Ability.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.Ability.Queries.GetListByInActive;
using AutoMapper;

namespace Application.Feature.AbilityFeatures.Ability.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {

        CreateMap<Domain.Abilities.Ability, CreateAbilityCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.Ability, CreateAbilityDto>().ReverseMap();

        CreateMap<Domain.Abilities.Ability, UpdateAbilityCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.Ability, UpdateAbilityDto>().ReverseMap();

        CreateMap<Domain.Abilities.Ability, ChangeStatusAbilityCommandResponse>().ReverseMap();

        CreateMap<Domain.Abilities.Ability, DeleteAbilityCommandResponse>().ReverseMap();

        CreateMap<UpdateAbilityDto, Domain.Abilities.Ability>();


        CreateMap<Domain.Abilities.Ability, RemoveAbilityCommandResponse>().ReverseMap();
        
        CreateMap<Domain.Abilities.Ability, GetByIdAbilityQueryResponse>().ReverseMap();
        CreateMap<Domain.Abilities.Ability, GetByIdAbilityDto>().ReverseMap();

        CreateMap<Domain.Abilities.Ability, GetListByActiveAbilityQueryResponse>().ReverseMap();
        
        CreateMap<Domain.Abilities.Ability, GetListByInActiveAbilityQueryResponse>().ReverseMap();
    }
}
  
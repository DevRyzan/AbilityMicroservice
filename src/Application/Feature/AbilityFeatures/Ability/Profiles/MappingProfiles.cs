using Application.Feature.AbilityFeatures.Ability.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.Ability.Commands.Create;
using AutoMapper;

namespace Application.Feature.AbilityFeatures.Ability.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Abilities.Ability, CreateAbilityCommandRequest>().ReverseMap();
        CreateMap<Domain.Abilities.Ability, CreateAbilityCommandResponse>().ReverseMap();

        CreateMap<Domain.Abilities.Ability, ChangeStatusAbilityCommandResponse>().ReverseMap();
    }
}

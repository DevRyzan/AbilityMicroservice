using Application.Feature.AbilityFeatures.AbilityCategory.Commands.Create;
using AutoMapper;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Profiles;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
        CreateMap<Domain.Abilities.AbilityCategory, CreateAbilityCategoryCommandRequest>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityCategory, CreatedAbilityCategoryCommandResponse>().ReverseMap();
    }
}

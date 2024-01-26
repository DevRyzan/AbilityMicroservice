using Application.Feature.AbilityFeatures.AbilityCategory.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityCategory.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityCategory.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityCategory.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityCategory.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetById;
using AutoMapper;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Profiles;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
        CreateMap<Domain.Abilities.AbilityCategory, CreateAbilityCategoryCommandRequest>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityCategory, CreatedAbilityCategoryCommandResponse>().ReverseMap();

        CreateMap<Domain.Abilities.AbilityCategoryDetailEng, CreateAbilityCategoryCommandRequest>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityCategory, ChangeStatusAbilityCategoryCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityCategory, DeletedAbilityCategoryCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityCategoryDetailEng, RemovedAbilityCategoryCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityCategoryDetailEng, UpdatedAbilityCategoryCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityCategoryDetailEng, GetByIdAbilityCategoryQueryResponse>().ReverseMap();
    }
}

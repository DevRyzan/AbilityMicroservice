using Application.Feature.AbilityFeatures.AbilityCategory.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityCategory.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityCategory.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityCategory.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityCategory.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityCategory.Queries.GetListByActive;
using AutoMapper;
using Domain.Abilities;

namespace Application.Feature.AbilityFeatures.AbilityCategory.Profiles;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
        CreateMap<Domain.Abilities.AbilityCategory, CreateAbilityCategoryCommandRequest>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityCategory, CreatedAbilityCategoryCommandResponse>().ReverseMap();

        CreateMap<AbilityCategoryDetailEng, CreateAbilityCategoryCommandRequest>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityCategory, ChangeStatusAbilityCategoryCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityCategory, DeletedAbilityCategoryCommandResponse>().ReverseMap();
        CreateMap<AbilityCategoryDetailEng, RemovedAbilityCategoryCommandResponse>().ReverseMap();
        CreateMap<AbilityCategoryDetailEng, UpdatedAbilityCategoryCommandResponse>().ReverseMap();
        CreateMap<AbilityCategoryDetailEng, GetByIdAbilityCategoryQueryResponse>().ReverseMap();


        CreateMap<AbilityCategoryDetailEng, GetListByActiveAbilityCategoryQueryResponse>().ReverseMap();
        //CreateMap<List<AbilityCategoryDetailEng>, List<GetListByActiveAbilityCategoryQueryResponse>>().ReverseMap();
    }
}

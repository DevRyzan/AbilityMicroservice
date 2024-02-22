using Application.Feature.AbilityFeatures.ResourceCostType.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.ResourceCostType.Commands.Create;
using Application.Feature.AbilityFeatures.ResourceCostType.Commands.Delete;
using Application.Feature.AbilityFeatures.ResourceCostType.Commands.Remove;
using Application.Feature.AbilityFeatures.ResourceCostType.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.ResourceCostType.Commands.Update;
using Application.Feature.AbilityFeatures.ResourceCostType.Dto;
using Application.Feature.AbilityFeatures.ResourceCostType.Queries.GetById;
using Application.Feature.AbilityFeatures.ResourceCostType.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.ResourceCostType.Queries.GetListByInActive;
using AutoMapper;

namespace Application.Feature.AbilityFeatures.ResourceCostType.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Abilities.ResourceCostType, ChangeStatusResourceCostTypeCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.ResourceCostType, CreateResourceCostTypeCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.ResourceCostType, CreateResourcesCostTypeDto>().ReverseMap();
        CreateMap<Domain.Abilities.ResourceCostType, DeleteResourceCostTypeCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.ResourceCostType, RemoveResourceCostTypeCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.ResourceCostType, UndoDeleteResourceCostTypeCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.ResourceCostType, UpdateResourceCostTypeCommandResponse>().ReverseMap();


        CreateMap<Domain.Abilities.ResourceCostType, GetByIdResourceCostTypeQueryResponse>().ReverseMap();
        CreateMap<Domain.Abilities.ResourceCostType, GetListByActiveResourceCostTypeQueryResponse>().ReverseMap();
        CreateMap<Domain.Abilities.ResourceCostType, GetListByInActiveResourceCostTypeQueryResponse>().ReverseMap();
    }
}

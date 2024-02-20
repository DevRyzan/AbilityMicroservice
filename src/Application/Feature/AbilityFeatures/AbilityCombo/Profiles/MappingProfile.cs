using Application.Feature.AbilityFeatures.AbilityCombo.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityCombo.Commands.Create;
using Application.Feature.AbilityFeatures.AbilityCombo.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityCombo.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityCombo.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityCombo.Dto;
using Application.Feature.AbilityFeatures.AbilityCombo.Queries.GetById;
using Application.Feature.AbilityFeatures.AbilityCombo.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.AbilityCombo.Queries.GetListByInActive;
using AutoMapper;

namespace Application.Feature.AbilityFeatures.AbilityCombo.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.Abilities.AbilityCombo, ChangeStatusAbilityComboCommandResponse>().ReverseMap();

        CreateMap<Domain.Abilities.AbilityCombo, CreateAbilityComboCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityCombo, CreateAbilityComboDto>().ReverseMap();
        
        CreateMap<Domain.Abilities.AbilityCombo, DeleteAbilityComboCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityCombo, RemoveAbilityComboCommandResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityCombo, UpdateAbilityComboCommandResponse>().ReverseMap();

        CreateMap<Domain.Abilities.AbilityCombo, GetByIdAbilityComboQueryResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityCombo, GetListByActiveAbilityComboQueryResponse>().ReverseMap();
        CreateMap<Domain.Abilities.AbilityCombo, GetListByInActiveAbilityComboQueryResponse>().ReverseMap();
    }
}

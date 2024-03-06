
using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Queries.GetListByInActive;

public class GetListByInActiveAbilityActivationTypeRequest : IRequest<List<GetListByInActiveAbilityActivationTypeResponse>>
{
    public PageRequest PageRequest { get; set; }

}

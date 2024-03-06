
using Core.Application.Requests;
using MediatR;

namespace Application.Feature.AbilityFeatures.AbilityActivationTypes.Queries.GetListByActive;

public class GetListByActiveAbilityActivationTypeRequest : IRequest<List<GetListByActiveAbilityActivationTypeResponse>>
{
    public PageRequest PageRequest { get; set; }

}

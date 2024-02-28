using Application.Feature.AbilityFeatures.Ability.Profiles;
using Application.Feature.AbilityFeatures.Ability.Queries.GetListByActive;
using Application.Feature.AbilityFeatures.Ability.Rules;
using Application.Service.AbilityServices.AbilityService;
using Application.Service.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Moq;
using Xunit;

namespace AbilityMicroservice.Test.Features.Ability.GetListByActive;

public class GetListByActiveAbilityTest
{
    [Fact]
    public async Task Handle_ShouldReturnListOfGetListByActiveAbilityQueryResponse_WhenPageRequestIsValid()
    {
        // Arrange
        var abilityService = new Mock<IAbilityService>();
        var abilityRepository = new Mock<IAbilityRepository>();
        var businessRules = new Mock<AbilityBusinessRules>();

        var myProfile = new MappingProfiles();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        IMapper mapper = new Mapper(configuration);

        // Mocked data
        var mockedAbilities = new List<Domain.Abilities.Ability>
        {

            new Domain.Abilities.Ability { Id = Guid.NewGuid().ToString() },
            new Domain.Abilities.Ability { Id = Guid.NewGuid().ToString() },
            // Add more mocked abilities as needed
        };

        businessRules.Setup(b => b.PageRequestShouldBeValid(It.IsAny<int>(), It.IsAny<int>())).Verifiable();
        abilityService.Setup(s => s.GetActiveList(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(mockedAbilities);

        var pageRequest = new PageRequest { Page = 1, PageSize = 10 };
        var queryRequest = new GetListByActiveAbilityQueryRequest { PageRequest = pageRequest };

        var handler = new GetListByActiveAbilityQueryHandler(abilityService.Object, businessRules.Object, mapper);

        // Act
        var result = await handler.Handle(queryRequest, It.IsAny<CancellationToken>());

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<GetListByActiveAbilityQueryResponse>>(result);

        businessRules.Verify();
        abilityService.Verify(s => s.GetActiveList(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
    }
}
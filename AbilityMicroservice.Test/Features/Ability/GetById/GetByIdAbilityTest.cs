using Application.Feature.AbilityFeatures.Ability.Dtos;
using Application.Feature.AbilityFeatures.Ability.Profiles;
using Application.Feature.AbilityFeatures.Ability.Queries.GetById;
using Application.Feature.AbilityFeatures.Ability.Rules;
using Application.Service.AbilityServices.AbilityService;
using Application.Service.Repositories;
using AutoMapper;
using Moq;
using Xunit;
using Assert = Xunit.Assert;


namespace AbilityMicroservice.Test.Features.Ability.GetById;

public class GetByIdAbilityTest
{
    [Fact]
    public async Task Should_Success_When_ValidIdGiven_GetById_Ability()
    {
        // Arrange
        var abilityService = new Mock<IAbilityService>();
        var abilityRepository = new Mock<IAbilityRepository>();
        var businessRules = new Mock<AbilityBusinessRules>(abilityRepository.Object);

        Domain.Abilities.Ability ability = new Domain.Abilities.Ability();
        ability.Id = Guid.NewGuid().ToString();

        var myProfile = new MappingProfiles();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        IMapper mapper = new Mapper(configuration);


        businessRules.Setup(br => br.IdShouldBeExist(It.IsAny<string>()));
        abilityService.Setup(s => s.GetById(It.IsAny<string>())).ReturnsAsync((ability));
        

        GetByIdAbilityQueryRequest _request = new GetByIdAbilityQueryRequest();
        GetByIdAbilityDto dto = new GetByIdAbilityDto();
        dto.Id = ability.Id;

        GetByIdAbilityQueryHandler _handler = new GetByIdAbilityQueryHandler(abilityService.Object, businessRules.Object, mapper);
        _request.GetByIdAbilityDto = dto;

        // Act
        var result = await _handler.Handle(_request, It.IsAny<CancellationToken>());

        // Assert
        Assert.NotNull(result);
        Assert.IsType<GetByIdAbilityQueryResponse>(result);
        Assert.Equal(result.Id, ability.Id);

        businessRules.Verify(br => br.IdShouldBeExist(It.IsAny<string>()), Times.Once);
        abilityService.Verify(s => s.GetById(It.IsAny<string>()), Times.Once);
    }
}
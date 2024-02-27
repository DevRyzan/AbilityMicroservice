using Application.Feature.AbilityFeatures.Ability.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.Ability.Commands.Delete;
using Application.Feature.AbilityFeatures.Ability.Dtos;
using Application.Feature.AbilityFeatures.Ability.Profiles;
using Application.Feature.AbilityFeatures.Ability.Rules;
using Application.Service.AbilityServices.AbilityService;
using Application.Service.Repositories;
using AutoMapper;
using Moq;
using Xunit;
using Assert = Xunit.Assert;


namespace AbilityMicroservice.Test.Features.Ability.Delete;

public class DeleteAbilityTest
{
    #region DeleteAbility
    [Fact]
    public async Task Should_Success_When_DeleteAbility()
    {
        // Arrange
        var abilityService = new Mock<IAbilityService>();
        var abilityRepository = new Mock<IAbilityRepository>();
        var businessRules = new Mock<AbilityBusinessRules>(abilityRepository.Object);

        var myProfile = new MappingProfiles();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        IMapper mapper = new Mapper(configuration);

        Domain.Abilities.Ability ability = new Domain.Abilities.Ability();
        ability.Id = Guid.NewGuid().ToString();

        businessRules.Setup(br => br.IdShouldBeExist(It.IsAny<string>()));

        abilityService.Setup(s => s.GetById(It.IsAny<string>())).ReturnsAsync((ability));

        abilityService.Setup(s => s.Update(It.IsAny<Domain.Abilities.Ability>()))
              .ReturnsAsync((Domain.Abilities.Ability _ability) => _ability);

        DeleteAbilityCommandRequest _request = new DeleteAbilityCommandRequest();
        DeleteAbilityDto dto = new DeleteAbilityDto();
        DeleteAbilityCommandHandler _handler = new DeleteAbilityCommandHandler(abilityService.Object, businessRules.Object, mapper);

        dto.Id = ability.Id;
        _request.DeleteAbilityDto = dto;

        // Action
        var result = await _handler.Handle(_request, It.IsAny<CancellationToken>());

        // Assert
        Assert.NotNull(result);
        Assert.IsType<DeleteAbilityCommandResponse>(result);
        Assert.Equal(false, result.Status);

        businessRules.Verify(br => br.IdShouldBeExist(It.IsAny<string>()), Times.Once);
        abilityService.Verify(s => s.GetById(It.IsAny<string>()), Times.Once);
        abilityService.Verify(s => s.Update(It.IsAny<Domain.Abilities.Ability>()), Times.Once);

    }
    #endregion DeleteAbility

}

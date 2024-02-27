using Application.Feature.AbilityFeatures.Ability.Commands.Update;
using Application.Feature.AbilityFeatures.Ability.Dtos;
using Application.Feature.AbilityFeatures.Ability.Profiles;
using Application.Feature.AbilityFeatures.Ability.Rules;
using Application.Service.AbilityServices.AbilityService;
using Application.Service.Repositories;
using AutoMapper;
using Moq;
using Xunit;
using static Application.Feature.AbilityFeatures.Ability.Commands.Update.UpdateAbilityCommandRequest;
using Assert = Xunit.Assert;


namespace AbilityMicroservice.Test.Features.Ability.Update;

public class UpdateAbilityTest
{
    #region UpdateAbility
    [Fact]
    public async Task Should_Success_When_UpdateAbility()
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

        UpdateAbilityCommandRequest _request = new UpdateAbilityCommandRequest();
        UpdateAbilityDto dto = new UpdateAbilityDto();
        dto.Id = ability.Id;
        UpdateAbilityDto mappedResponse = mapper.Map<UpdateAbilityDto>(ability);

        UpdateAbilityCommandHandler _handler = new UpdateAbilityCommandHandler(abilityService.Object, businessRules.Object, mapper);
        _request.UpdateAbilityDto = dto;

        // Action
        var result = await _handler.Handle(_request, It.IsAny<CancellationToken>());

        // Assert
        Assert.NotNull(result);
        Assert.IsType<UpdateAbilityCommandResponse>(result);
        Assert.Equal(result.Id, _request.UpdateAbilityDto.Id);

        businessRules.Verify(br => br.IdShouldBeExist(It.IsAny<string>()), Times.Once);
        abilityService.Verify(s => s.GetById(It.IsAny<string>()), Times.Once);
        abilityService.Verify(s => s.Update(It.IsAny<Domain.Abilities.Ability>()), Times.Once);
    }
    #endregion UpdateAbility
}

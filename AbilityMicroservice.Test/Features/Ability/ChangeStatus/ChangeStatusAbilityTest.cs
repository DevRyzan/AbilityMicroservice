using Application.Feature.AbilityFeatures.Ability.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.Ability.Dtos;
using Application.Feature.AbilityFeatures.Ability.Profiles;
using Application.Feature.AbilityFeatures.Ability.Rules;
using Application.Service.AbilityServices.AbilityService;
using Application.Service.Repositories;
using AutoMapper;
using Moq;
using Xunit;
using static Application.Feature.AbilityFeatures.Ability.Commands.ChangeStatus.ChangeStatusAbilityCommandRequest;
using Assert = Xunit.Assert;


namespace AbilityMicroservice.Test.Features.Ability.ChangeStatus;

public class AbilityHandlerTests
{

    #region ChangeStatusAbility
    [Fact]
    public async Task Should_Success_When_ChangeStatusAbility()
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

        businessRules.Setup(br => br.IdShouldBeExist(It.IsAny<string>())); //.Returns(Task.CompletedTask);

        abilityService.Setup(s => s.GetById(It.IsAny<string>())).ReturnsAsync((ability));

        abilityService.Setup(s => s.Update(It.IsAny<Domain.Abilities.Ability>()))
              .ReturnsAsync((Domain.Abilities.Ability _ability) => _ability);

        ChangeStatusAbilityCommandRequest _request = new ChangeStatusAbilityCommandRequest();
        ChangeStatusAbilityDto dto = new ChangeStatusAbilityDto();
        dto.Id = ability.Id;
        ChangeStatusAbilityCommandHandler _handler = new ChangeStatusAbilityCommandHandler(abilityService.Object, businessRules.Object, mapper);

        _request.ChangeStatusAbilityDto = dto;
        
        // Action
        var result = await _handler.Handle(_request, It.IsAny<CancellationToken>());

        // Assert
        Assert.NotNull(result);
        Assert.IsType<ChangeStatusAbilityCommandResponse>(result);
        Assert.Equal(result.Id, _request.ChangeStatusAbilityDto.Id);

        businessRules.Verify(br => br.IdShouldBeExist(It.IsAny<string>()), Times.Once);
        abilityService.Verify(s => s.GetById(It.IsAny<string>()), Times.Once);
        abilityService.Verify(s => s.Update(It.IsAny<Domain.Abilities.Ability>()), Times.Once);

    }
    #endregion ChangeStatusAbility

}
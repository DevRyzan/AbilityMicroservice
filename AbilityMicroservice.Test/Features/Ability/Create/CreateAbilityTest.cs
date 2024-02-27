using Application.Feature.AbilityFeatures.Ability.Commands.Create;
using Application.Feature.AbilityFeatures.Ability.Dtos;
using Application.Feature.AbilityFeatures.Ability.Profiles;
using Application.Feature.AbilityFeatures.Ability.Rules;
using Application.Service.AbilityServices.AbilityComboService;
using Application.Service.AbilityServices.AbilityLevelService;
using Application.Service.AbilityServices.AbilityService;
using Application.Service.Repositories;
using AutoMapper;
using Moq;
using Xunit;
using static Application.Feature.AbilityFeatures.Ability.Commands.Create.CreateAbilityCommandRequest;
using Assert = Xunit.Assert;


namespace AbilityMicroservice.Test.Features.Ability.Create;

public class CreateAbilityTest
{
    #region CreateAbility
    [Fact]
    public async Task Should_Success_When_UpdateAbility()
    {
        // Arrange
        var abilityService = new Mock<IAbilityService>();
        var abilityComboService = new Mock<IAbilityComboService>();
        var abilityLevelService = new Mock<IAbilityLevelService>();
        var abilityRepository = new Mock<IAbilityRepository>();
        var businessRules = new Mock<AbilityBusinessRules>(abilityRepository.Object);

        var myProfile = new MappingProfiles();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        IMapper mapper = new Mapper(configuration);

        Domain.Abilities.Ability ability = new Domain.Abilities.Ability();
        ability.Id = Guid.NewGuid().ToString();
        ability.AbilityTypeId = Guid.NewGuid().ToString();
        ability.TargetTypeId = Guid.NewGuid().ToString();
        ability.DamageTypeId = Guid.NewGuid().ToString();
        ability.AffectUnıtId = Guid.NewGuid().ToString();
        ability.CastTimeTypeId = Guid.NewGuid().ToString();

        abilityService.Setup(s => s.Create(It.IsAny<Domain.Abilities.Ability>()))
            .ReturnsAsync((Domain.Abilities.Ability _ability) => _ability);

        CreateAbilityCommandRequest _request = new CreateAbilityCommandRequest();
        CreateAbilityDto dto = new CreateAbilityDto();
        CreateAbilityCommandResponse response = new CreateAbilityCommandResponse();

        CreateAbilityCommandHandler _handler = new CreateAbilityCommandHandler(mapper, abilityService.Object, abilityComboService.Object, abilityLevelService.Object);
        _request.CreateAbilityDto = dto;

        dto = mapper.Map<CreateAbilityDto>(ability);

        // Action
        var result = await _handler.Handle(_request, It.IsAny<CancellationToken>());

        // Assert
        Assert.NotNull(result.Id);
        Assert.IsType<CreateAbilityCommandResponse>(result);
        Assert.Equal(true, result.Status);

        abilityService.Verify(s => s.Create(It.IsAny<Domain.Abilities.Ability>()), Times.Once);
    }
    #endregion CreateAbility
}

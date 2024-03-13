using Application.Feature.AbilityFeatures.Ability.Commands.Remove;
using Application.Feature.AbilityFeatures.Ability.Dtos;
using Application.Feature.AbilityFeatures.Ability.Rules;
using Application.Service.AbilityServices.AbilityService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;

namespace Unit.Test.Abilities;

public class RemoveAbilityCommandHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityService> _abilityServiceMock;
    private readonly Mock<IAbilityRepository> _abilityRepositoryMock;
    private readonly Mock<AbilityBusinessRules> _abilityBusinessRulesMock;

    public RemoveAbilityCommandHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityServiceMock = new Mock<IAbilityService>();
        _abilityRepositoryMock = new Mock<IAbilityRepository>();
        _abilityBusinessRulesMock = new Mock<AbilityBusinessRules>();
    }


    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task Ability_RemoveHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityBusinessRules>(_abilityRepositoryMock.Object);

        var handler = new RemoveAbilityCommandHandler(_abilityServiceMock.Object, _abilityBusinessRulesMock.Object, _mapperMock.Object);

        var request = new RemoveAbilityCommandRequest
        {
            RemoveAbilityDto = new RemoveAbilityDto
            {
                Id = id
            }
        };

        var ability = new Ability
        {
            Id = id,
            Status = true,
            IsDeleted = false
        };

        var expectedResponse = new RemoveAbilityCommandResponse
        {
            Id = id,
            Status = !ability.Status,
            IsDeleted = false,
        };

        _mapperMock.Setup(m => m.Map<Ability>(request.RemoveAbilityDto))
                   .Returns(ability);

        _abilityServiceMock.Setup(m => m.GetById(id))
                                    .ReturnsAsync(ability);

        _abilityServiceMock.Setup(m => m.Remove(ability))
                                    .ReturnsAsync(ability);

        _mapperMock.Setup(m => m.Map<RemoveAbilityCommandResponse>(ability))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Status, response.Status);

        _abilityServiceMock.Verify(m => m.GetById(ability.Id), Times.Once);
        _abilityServiceMock.Verify(m => m.Remove(ability), Times.Once);

    }
}

using Application.Feature.AbilityFeatures.Ability.Commands.Update;
using Application.Feature.AbilityFeatures.Ability.Dtos;
using Application.Feature.AbilityFeatures.Ability.Rules;
using Application.Service.AbilityServices.AbilityService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;

namespace Unit.Test.Abilities;

public class UpdateAbilityCommandHandlerTest
{
    public static IEnumerable<object[]> UpdateAbilityDtoTestData()
    {
        yield return new object[] { new UpdateAbilityDto { } };
    }

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityService> _abilityServiceMock;
    private readonly Mock<IAbilityRepository> _abilityRepositoryMock;
    private readonly Mock<AbilityBusinessRules> _abilityBusinessRulesMock;

    public UpdateAbilityCommandHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityServiceMock = new Mock<IAbilityService>();
        _abilityRepositoryMock = new Mock<IAbilityRepository>();
        _abilityBusinessRulesMock = new Mock<AbilityBusinessRules>();
    }

    [Theory]
    [MemberData(nameof(UpdateAbilityDtoTestData))]
    public async Task AbilityDeleteHandler_ValidRequest_ReturnsResponse(UpdateAbilityDto updateAbilityDto)
    {
        var businessRuleMock = new Mock<AbilityBusinessRules>(_abilityRepositoryMock.Object);

        var handler = new UpdateAbilityCommandHandler(_abilityServiceMock.Object, _abilityBusinessRulesMock.Object, _mapperMock.Object);

        var request = new UpdateAbilityCommandRequest
        {
            UpdateAbilityDto = updateAbilityDto
        };

        var ability = new Ability
        {
            Id = request.UpdateAbilityDto.Id,
            Name = request.UpdateAbilityDto.Name,
            Description = request.UpdateAbilityDto.Description,
        };

        var expectedResponse = new UpdateAbilityCommandResponse
        {
            Id = request.UpdateAbilityDto.Id,
            Name = request.UpdateAbilityDto.Name,
            Description = request.UpdateAbilityDto.Description,
        };

        _mapperMock.Setup(m => m.Map<Ability>(request.UpdateAbilityDto))
                   .Returns(ability);

        _abilityServiceMock.Setup(m => m.GetById(ability.Id))
                                    .ReturnsAsync(ability);

        _abilityServiceMock.Setup(m => m.Update(ability))
                                    .ReturnsAsync(ability);

        _mapperMock.Setup(m => m.Map<UpdateAbilityCommandResponse>(ability))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityServiceMock.Verify(m => m.GetById(ability.Id), Times.Once);
        _abilityServiceMock.Verify(m => m.Update(ability), Times.Once);

    }
}

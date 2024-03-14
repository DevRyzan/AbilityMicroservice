using Application.Feature.AbilityFeatures.AbilityAffectUnits.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Dto;
using Application.Feature.AbilityFeatures.AbilityAffectUnits.Rules;
using Application.Service.AbilityServices.AbilityAffectUnitService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;


namespace Unit.Test.AbilityAffectUnits;

public class UpdateAbilityAffectUnitHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityAffectUnitService> _abilityAffectUnitServiceMock;
    private readonly Mock<IAbilityAffectUnitRepository> _abilityAffectUnitRepositoryMock;
    private readonly Mock<AbilityAffectUnitBusinessRules> _abilityAffectUnitBusinessRulesMock;

    public UpdateAbilityAffectUnitHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityAffectUnitServiceMock = new Mock<IAbilityAffectUnitService>();
        _abilityAffectUnitRepositoryMock = new Mock<IAbilityAffectUnitRepository>();
        _abilityAffectUnitBusinessRulesMock = new Mock<AbilityAffectUnitBusinessRules>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32", "xxx")]
    public async Task AbilityAffectUnit_UpdateHandler_ValidRequest_ReturnsResponse(string id, string name)
    {
        var businessRuleMock = new Mock<AbilityAffectUnitBusinessRules>(_abilityAffectUnitRepositoryMock.Object);

        var handler = new UpdateAbilityAffectUnitHandler(
            _abilityAffectUnitServiceMock.Object,
            businessRuleMock.Object,
            _mapperMock.Object
        );

        var request = new UpdateAbilityAffectUnitRequest
        {
            UpdateAbilityAffectUnitDto = new UpdateAbilityAffectUnitDto
            {
                Id = id,
                Name = name
            }
        };

        var abilityAffectUnit = new AbilityAffectUnit
        {
            Id = id,
            Name = name,
            Status = true,
            IsDeleted = false
        };

        var expectedResponse = new UpdateAbilityAffectUnitResponse
        {
            Id = id,
            Name = "vvv"
        };

        _mapperMock.Setup(m => m.Map<AbilityAffectUnit>(request.UpdateAbilityAffectUnitDto))
                   .Returns(abilityAffectUnit);

        _abilityAffectUnitServiceMock.Setup(m => m.GetById(id))
                                    .ReturnsAsync(abilityAffectUnit);

        _abilityAffectUnitServiceMock.Setup(m => m.Update(abilityAffectUnit))
                                    .ReturnsAsync(abilityAffectUnit);

        _mapperMock.Setup(m => m.Map<UpdateAbilityAffectUnitResponse>(abilityAffectUnit))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityAffectUnitServiceMock.Verify(m => m.Update(abilityAffectUnit), Times.Once);
    }
}

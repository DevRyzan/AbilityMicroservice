using Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Remove;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;


namespace Unit.Test.AbilityEffectTypes;

public class RemoveAbilityEffectTypeHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityEffectTypeService> _abilityEffectTypeServiceMock;
    private readonly Mock<IAbilityEffectTypeRepository> _abilityEffectTypeRepositoryMock;
    private readonly Mock<AbilityEffectTypeBusinessRules> _abilityEffectTypeBusinessRulesMock;

    public RemoveAbilityEffectTypeHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityEffectTypeServiceMock = new Mock<IAbilityEffectTypeService>();
        _abilityEffectTypeRepositoryMock = new Mock<IAbilityEffectTypeRepository>();
        _abilityEffectTypeBusinessRulesMock = new Mock<AbilityEffectTypeBusinessRules>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityEffectType_RemoveHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityEffectTypeBusinessRules>(_abilityEffectTypeRepositoryMock.Object);

        var handler = new RemoveAbilityEffectTypeHandler(_abilityEffectTypeServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new RemoveAbilityEffectTypeRequest
        {
            RemoveAbilityEffectTypeDto = new RemoveAbilityEffectTypeDto
            {
                Id = id
            }
        };

        var abilityEffectType = new AbilityEffectType
        {
            Id = id,
            IsDeleted = false,
            Status = true
        };

        var expectedResponse = new RemoveAbilityEffectTypeResponse
        {
            Id = id
        };

        _mapperMock.Setup(m => m.Map<AbilityEffectType>(request.RemoveAbilityEffectTypeDto))
                   .Returns(abilityEffectType);

        _abilityEffectTypeServiceMock.Setup(m => m.GetById(id))
                                        .ReturnsAsync(abilityEffectType);

        _abilityEffectTypeServiceMock.Setup(m => m.Remove(abilityEffectType))
                                        .ReturnsAsync(abilityEffectType);

        _mapperMock.Setup(m => m.Map<RemoveAbilityEffectTypeResponse>(abilityEffectType))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityEffectTypeServiceMock.Verify(m => m.GetById(abilityEffectType.Id), Times.Once);
        _abilityEffectTypeServiceMock.Verify(m => m.Remove(abilityEffectType), Times.Once);
    }
}

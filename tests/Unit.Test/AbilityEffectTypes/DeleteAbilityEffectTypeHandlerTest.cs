using Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Delete;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;


namespace Unit.Test.AbilityEffectTypes;

public class DeleteAbilityEffectTypeHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityEffectTypeService> _abilityEffectTypeServiceMock;
    private readonly Mock<IAbilityEffectTypeRepository> _abilityEffectTypeRepositoryMock;
    private readonly Mock<AbilityEffectTypeBusinessRules> _abilityEffectTypeBusinessRulesMock;

    public DeleteAbilityEffectTypeHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityEffectTypeServiceMock = new Mock<IAbilityEffectTypeService>();
        _abilityEffectTypeRepositoryMock = new Mock<IAbilityEffectTypeRepository>();
        _abilityEffectTypeBusinessRulesMock = new Mock<AbilityEffectTypeBusinessRules>();
    }

    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityEffectType_DeleteHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityEffectTypeBusinessRules>(_abilityEffectTypeRepositoryMock.Object);

        var handler = new DeleteAbilityEffectTypeHandler(_abilityEffectTypeServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new DeleteAbilityEffectTypeRequest
        {
            DeleteAbilityEffectTypeDto = new DeleteAbilityEffectTypeDto
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

        var expectedResponse = new DeleteAbilityEffectTypeResponse
        {
            Id = id,
            Status = !abilityEffectType.Status,
            IsDeleted = false,
        };

        _mapperMock.Setup(m => m.Map<AbilityEffectType>(request.DeleteAbilityEffectTypeDto))
                   .Returns(abilityEffectType);

        _abilityEffectTypeServiceMock.Setup(m => m.GetById(id))
                                        .ReturnsAsync(abilityEffectType);

        _abilityEffectTypeServiceMock.Setup(m => m.Delete(abilityEffectType))
                                        .ReturnsAsync(abilityEffectType);

        _mapperMock.Setup(m => m.Map<DeleteAbilityEffectTypeResponse>(abilityEffectType))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Status, response.Status);

        _abilityEffectTypeServiceMock.Verify(m => m.GetById(abilityEffectType.Id), Times.Once);
        _abilityEffectTypeServiceMock.Verify(m => m.Delete(abilityEffectType), Times.Once);
    }
}

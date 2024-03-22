using Application.Feature.AbilityFeatures.AbilityEffectTypes.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffectTypes.Rules;
using Application.Service.AbilityServices.AbilityEffectTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using Moq;
using Xunit;

namespace Unit.Test.AbilityEffectTypes;

public class UpdateAbilityEffectTypeHandlerTest
{
    public static IEnumerable<object[]> UpdateAbilityEffectTypeDtoTestData()
    {
        yield return new object[] { new UpdateAbilityEffectTypeDto {
            Name = "nameTest",
            Description = "descriptionTest"
        } };
    }

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityEffectTypeService> _abilityEffectTypeServiceMock;
    private readonly Mock<IAbilityEffectTypeRepository> _abilityEffectTypeRepositoryMock;
    private readonly Mock<AbilityEffectTypeBusinessRules> _abilityEffectTypeBusinessRulesMock;

    public UpdateAbilityEffectTypeHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityEffectTypeServiceMock = new Mock<IAbilityEffectTypeService>();
        _abilityEffectTypeRepositoryMock = new Mock<IAbilityEffectTypeRepository>();
        _abilityEffectTypeBusinessRulesMock = new Mock<AbilityEffectTypeBusinessRules>();
    }

    [Theory]
    [MemberData(nameof(UpdateAbilityEffectTypeDtoTestData))]
    public async Task AbilityEffectType_UpdateHandler_ValidRequest_ReturnsResponse(UpdateAbilityEffectTypeDto updateAbilityEffectTypeDto)
    {
        var businessRuleMock = new Mock<AbilityEffectTypeBusinessRules>(_abilityEffectTypeRepositoryMock.Object);

        var handler = new UpdateAbilityEffectTypeHandler(_abilityEffectTypeServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new UpdateAbilityEffectTypeRequest
        {
            UpdateAbilityEffectTypeDto = updateAbilityEffectTypeDto
        };

        var abilityEffectType = new AbilityEffectType
        {
            Id = request.UpdateAbilityEffectTypeDto.Id,
            Name = "nameTest",
            Description = "descriptionTest"
        };

        var expectedResponse = new UpdateAbilityEffectTypeResponse
        {
            Id = request.UpdateAbilityEffectTypeDto.Id,
            Name = "nameTest",
            Description = "descriptionTest"
        };

        _mapperMock.Setup(m => m.Map<AbilityEffectType>(request.UpdateAbilityEffectTypeDto))
                   .Returns(abilityEffectType);

        _abilityEffectTypeServiceMock.Setup(m => m.GetById(abilityEffectType.Id))
                                    .ReturnsAsync(abilityEffectType);

        _abilityEffectTypeServiceMock.Setup(m => m.Update(abilityEffectType))
                                    .ReturnsAsync(abilityEffectType);

        _mapperMock.Setup(m => m.Map<UpdateAbilityEffectTypeResponse>(abilityEffectType))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityEffectTypeServiceMock.Verify(m => m.GetById(abilityEffectType.Id), Times.Once);
        _abilityEffectTypeServiceMock.Verify(m => m.Update(abilityEffectType), Times.Once);
    }
}

using Application.Feature.AbilityFeatures.AbilityCombo.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityCombo.Dto;
using Application.Feature.AbilityFeatures.AbilityCombo.Rules;
using Application.Feature.AbilityFeatures.AbilityEffects.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityEffects.Dtos;
using Application.Feature.AbilityFeatures.AbilityEffects.Rules;
using Application.Service.AbilityServices.AbilityEffectService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using MongoDB.Bson;
using Moq;
using Xunit;


namespace Unit.Test.AbilityEffects;

public class UpdateAbilityEffectHandlerTest
{
    public static IEnumerable<object[]> UpdateAbilityEffectDtoTestData()
    {
        yield return new object[] { new UpdateAbilityEffectDto {
            AbilityId = ObjectId.GenerateNewId().ToString(),
            Name = "string" 
        } };
    }

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityEffectService> _abilityEffectServiceMock;
    private readonly Mock<IAbilityEffectRepository> _abilityEffectRepositoryMock;
    private readonly Mock<AbilityEffectBusinessRules> _abilityEffectBusinessRulesMock;

    public UpdateAbilityEffectHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityEffectServiceMock = new Mock<IAbilityEffectService>();
        _abilityEffectRepositoryMock = new Mock<IAbilityEffectRepository>();
        _abilityEffectBusinessRulesMock = new Mock<AbilityEffectBusinessRules>();
    }

    [Theory]
    [MemberData(nameof(UpdateAbilityEffectDtoTestData))]
    public async Task AbilityAllyEffectStat_UpdateHandler_ValidRequest_ReturnsResponse(UpdateAbilityEffectDto updateAbilityEffectDto)
    {
        var businessRuleMock = new Mock<AbilityEffectBusinessRules>(_abilityEffectRepositoryMock.Object);

        var handler = new UpdateAbilityEffectHandler(_abilityEffectServiceMock.Object, businessRuleMock.Object, _mapperMock.Object);

        var request = new UpdateAbilityEffectRequest
        {
            UpdateAbilityEffectDto = updateAbilityEffectDto
        };

        var abilityEffect = new AbilityEffect
        {
            Id = request.UpdateAbilityEffectDto.Id,
            AbilityId = request.UpdateAbilityEffectDto.AbilityId
        };

        var expectedResponse = new UpdateAbilityEffectResponse
        {
            Id = request.UpdateAbilityEffectDto.Id,
            AbilityId = request.UpdateAbilityEffectDto.AbilityId
        };

        _mapperMock.Setup(m => m.Map<AbilityEffect>(request.UpdateAbilityEffectDto))
                   .Returns(abilityEffect);

        _abilityEffectServiceMock.Setup(m => m.GetById(abilityEffect.Id))
                                    .ReturnsAsync(abilityEffect);

        _abilityEffectServiceMock.Setup(m => m.Update(abilityEffect))
                                    .ReturnsAsync(abilityEffect);

        _mapperMock.Setup(m => m.Map<UpdateAbilityEffectResponse>(abilityEffect))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityEffectServiceMock.Verify(m => m.GetById(abilityEffect.Id), Times.Once);
        _abilityEffectServiceMock.Verify(m => m.Update(abilityEffect), Times.Once);
    }

}

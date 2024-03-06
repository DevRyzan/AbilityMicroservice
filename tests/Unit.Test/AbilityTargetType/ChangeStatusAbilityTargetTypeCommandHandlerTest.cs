using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.AbilityTargetType.Dto;
using Application.Feature.AbilityFeatures.AbilityTargetType.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Moq;
using Xunit;

namespace Unit.Test.AbilityTargetType;

public class ChangeStatusAbilityTargetTypeCommandHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityTargetTypeService> _abilityTargetTypeServiceMock;
    private readonly Mock<IAbilityTargetTypeRepository> _abilityTargetTypeRepositoryMock;
    private readonly Mock<IAbilityRepository> _abilityRepositoryMock;
    private readonly Mock<AbilityTargetTypeBusinessRules> _abilityTargetTypeBusinessRulesMock;

    public ChangeStatusAbilityTargetTypeCommandHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityTargetTypeBusinessRulesMock = new Mock<AbilityTargetTypeBusinessRules>();
        _abilityTargetTypeServiceMock = new Mock<IAbilityTargetTypeService>();
        _abilityTargetTypeRepositoryMock = new Mock<IAbilityTargetTypeRepository>();
        _abilityRepositoryMock = new Mock<IAbilityRepository>();
    }



    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task AbilityTargetTypeHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<AbilityTargetTypeBusinessRules>(_abilityTargetTypeRepositoryMock.Object, _abilityRepositoryMock.Object);

        var handler = new ChangeStatusAbilityTargetTypeCommandHandler(_mapperMock.Object, businessRuleMock.Object, _abilityTargetTypeServiceMock.Object);

        var request = new ChangeStatusAbilityTargetTypeCommandRequest
        {
            ChangeStatusAbilityTargetTypeDto = new ChangeStatusAbilityTargetTypeDto
            {
                Id = id
            }
        };

        var abilityTargetType = new Domain.Abilities.AbilityTargetType
        {
            Id = id,
            Status = true,
            IsDeleted = false
        };

        var expectedResponse = new ChangeStatusAbilityTargetTypeCommandResponse
        {
            Id = id,
            Status = !abilityTargetType.Status,
            IsDeleted = false,
        };

        _mapperMock.Setup(m => m.Map<Domain.Abilities.AbilityTargetType>(request.ChangeStatusAbilityTargetTypeDto))
                   .Returns(abilityTargetType);

        _abilityTargetTypeServiceMock.Setup(m => m.GetById(id))
                                    .ReturnsAsync(abilityTargetType);

        _abilityTargetTypeServiceMock.Setup(m => m.Update(abilityTargetType))
                                    .ReturnsAsync(abilityTargetType);

        _mapperMock.Setup(m => m.Map<ChangeStatusAbilityTargetTypeCommandResponse>(abilityTargetType))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Status, response.Status);

        _abilityTargetTypeServiceMock.Verify(m => m.GetById(abilityTargetType.Id), Times.Once);
    }
}

using Application.Feature.AbilityFeatures.AbilityTargetType.Commands.Update;
using Application.Feature.AbilityFeatures.AbilityTargetType.Dto;
using Application.Feature.AbilityFeatures.AbilityTargetType.Rules;
using Application.Service.AbilityServices.AbilityTargetTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Moq;
using Xunit;

namespace Unit.Test.AbilityTargetType;

public class UpdateAbilityTargetTypeCommandHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityTargetTypeService> _abilityTargetTypeServiceMock;
    private readonly Mock<IAbilityTargetTypeRepository> _abilityTargetTypeRepositoryMock;
    private readonly Mock<IAbilityRepository> _abilityRepositoryMock;
    private readonly Mock<AbilityTargetTypeBusinessRules> _abilityTargetTypeBusinessRulesMock;

    public UpdateAbilityTargetTypeCommandHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityTargetTypeBusinessRulesMock = new Mock<AbilityTargetTypeBusinessRules>();
        _abilityTargetTypeServiceMock = new Mock<IAbilityTargetTypeService>();
        _abilityTargetTypeRepositoryMock = new Mock<IAbilityTargetTypeRepository>();
        _abilityRepositoryMock = new Mock<IAbilityRepository>();
    }



    [Theory]
    [InlineData("65e6071da3101fa3c673ef32", "xxx", "xxxxx")]
    public async Task AbilityTargetTypeHandler_ValidRequest_ReturnsResponse(string id, string name, string description)
    {
        var businessRuleMock = new Mock<AbilityTargetTypeBusinessRules>(_abilityTargetTypeRepositoryMock.Object, _abilityRepositoryMock.Object);

        var handler = new UpdateAbilityTargetTypeCommandHandler(_mapperMock.Object, businessRuleMock.Object, _abilityTargetTypeServiceMock.Object);

        var request = new UpdateAbilityTargetTypeCommandRequest
        {
            UpdateAbilityTargetTypeDto = new UpdateAbilityTargetTypeDto
            {
                Id = id,
                Name = name,
                Description = description
            }
        };

        var abilityTargetType = new Domain.Abilities.AbilityTargetType
        {
            Id = id,
            Name = name,
            Description = description,
            IsDeleted = true,
            Status = false
        };

        var expectedResponse = new UpdateAbilityTargetTypeCommandResponse
        {
            Id = id,
            Name = name,
            Description = description,
            IsDeleted = true,
            Status = false

        };

        _mapperMock.Setup(m => m.Map<Domain.Abilities.AbilityTargetType>(request.UpdateAbilityTargetTypeDto))
                   .Returns(abilityTargetType);

        _abilityTargetTypeServiceMock.Setup(m => m.GetById(abilityTargetType.Id))
                            .ReturnsAsync(abilityTargetType);

        _abilityTargetTypeServiceMock.Setup(m => m.Update(abilityTargetType))
                                    .ReturnsAsync(abilityTargetType);

        _mapperMock.Setup(m => m.Map<UpdateAbilityTargetTypeCommandResponse>(abilityTargetType))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _abilityTargetTypeServiceMock.Verify(m => m.Update(abilityTargetType), Times.Once);
    }
}

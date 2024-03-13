using Application.Feature.AbilityFeatures.Ability.Commands.ChangeStatus;
using Application.Feature.AbilityFeatures.Ability.Commands.Create;
using Application.Feature.AbilityFeatures.Ability.Dtos;
using Application.Feature.AbilityFeatures.Ability.Rules;
using Application.Service.AbilityServices.AbilityComboService;
using Application.Service.AbilityServices.AbilityLevelService;
using Application.Service.AbilityServices.AbilityService;
using Application.Service.Repositories;
using AutoMapper;
using Domain.Abilities;
using MongoDB.Bson;
using Moq;
using Xunit;


namespace Unit.Test.Abilities;

public class CreateAbilityCommandHandlerTest
{
    public static IEnumerable<object[]> CreateAbilityDtoTestData()
    {
        yield return new object[] { new CreateAbilityDto { } };
    }


    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IAbilityService> _abilityServiceMock;
    private readonly Mock<IAbilityComboService> _abilityComboServiceMock;
    private readonly Mock<IAbilityLevelService> _abilityLevelServiceMock;
    private readonly Mock<IAbilityRepository> _abilityRepositoryMock;
    private readonly Mock<AbilityBusinessRules> _abilityBusinessRulesMock;
    
    public CreateAbilityCommandHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _abilityServiceMock = new Mock<IAbilityService>();
        _abilityRepositoryMock = new Mock<IAbilityRepository>();
        _abilityBusinessRulesMock = new Mock<AbilityBusinessRules>();
        _abilityLevelServiceMock = new Mock<IAbilityLevelService>();
        _abilityComboServiceMock = new Mock<IAbilityComboService>();
    }

    [Theory]
    [MemberData(nameof(CreateAbilityDtoTestData))]
    public async Task Ability_CreateHandler_ValidRequest_ReturnsResponse(CreateAbilityDto createAbilityDto)
    {
        var businessRuleMock = new Mock<AbilityBusinessRules>(_abilityRepositoryMock.Object);

        var handler = new CreateAbilityCommandHandler(_mapperMock.Object, _abilityServiceMock.Object, _abilityComboServiceMock.Object, _abilityLevelServiceMock.Object);

        var request = new CreateAbilityCommandRequest
        {
            CreateAbilityDto = createAbilityDto
        };

        var ability = new Ability
        {
            Id = ObjectId.GenerateNewId().ToString(),
            Name = request.CreateAbilityDto.Name,
            Description = request.CreateAbilityDto.Description,
        };

        _mapperMock.Setup(m => m.Map(request.CreateAbilityDto, ability));

        var expectedResponse = new ChangeStatusAbilityCommandResponse
        {
            Id = ability.Id,
            Name = request.CreateAbilityDto.Name,
            Description = request.CreateAbilityDto.Description,
        };

        _mapperMock.Setup(m => m.Map<Ability>(request.CreateAbilityDto))
                   .Returns(ability);

        _abilityServiceMock.Setup(m => m.Create(ability))
                                    .ReturnsAsync(ability);

        _mapperMock.Setup(m => m.Map<ChangeStatusAbilityCommandResponse>(ability))
                  .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Name, ability.Name);

        _abilityServiceMock.Verify(m => m.Create(ability), Times.Once);

    }
}

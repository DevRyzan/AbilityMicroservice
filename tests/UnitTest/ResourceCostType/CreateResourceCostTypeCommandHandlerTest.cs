using Application.Feature.AbilityFeatures.ResourceCostType.Commands.Create;
using Application.Feature.AbilityFeatures.ResourceCostType.Dto;
using Application.Feature.AbilityFeatures.ResourceCostType.Rules;
using Application.Service.AbilityServices.ResourceCostTypeService;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.ResourceCostType;
public class CreateResourceCostTypeCommandHandlerTest
{

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IResourceCostTypeService> _resourceCostTypeServiceMock;
    private readonly Mock<ResourceCostTypeBusinessRules> _resourceCostTypeBusinessRulesMock;

    public CreateResourceCostTypeCommandHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _resourceCostTypeBusinessRulesMock = new Mock<ResourceCostTypeBusinessRules>();
        _resourceCostTypeServiceMock = new Mock<IResourceCostTypeService>();
    }

    [Theory]
    [InlineData("Hourly")]
    [InlineData("Wood")]
    [InlineData("Stone")]
    [InlineData("Iron")]
    public async Task ResourceCostTypeHandle_ValidRequest_ReturnsResponse(string name)
    {

        var handler = new CreateResourceCostTypeCommandHandler(
            _mapperMock.Object,
            _resourceCostTypeServiceMock.Object,
            _resourceCostTypeBusinessRulesMock.Object
        );

        var request = new CreateResourceCostTypeCommandRequest
        {
            CreateResourcesCostTypeDto = new CreateResourcesCostTypeDto
            {
                Name = name
            }
        };

        var expectedResourceCostType = new Domain.Abilities.ResourceCostType
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.CreateResourcesCostTypeDto.Name,
            Status = true,
            IsDeleted = false,
            CreatedDate = DateTime.Now
        };

        var expectedResponse = new CreateResourceCostTypeCommandResponse
        {

            Id = expectedResourceCostType.Id,
            Name = expectedResourceCostType.Name,
            Status = true, 
            IsDeleted = false, 
            CreatedDate = DateTime.Now, 
        };

        _mapperMock.Setup(m => m.Map<Domain.Abilities.ResourceCostType>(request.CreateResourcesCostTypeDto))
            .Returns(expectedResourceCostType);

        _resourceCostTypeServiceMock.Setup(m => m.Create(expectedResourceCostType))
            .ReturnsAsync(expectedResourceCostType);

        _mapperMock.Setup(m => m.Map<CreateResourceCostTypeCommandResponse>(expectedResourceCostType))
            .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _resourceCostTypeServiceMock.Verify(m => m.Create(expectedResourceCostType), Times.Once);
    }
}


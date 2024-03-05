using Application.Feature.AbilityFeatures.ResourceCostType.Commands.Update;
using Application.Feature.AbilityFeatures.ResourceCostType.Dto;
using Application.Feature.AbilityFeatures.ResourceCostType.Rules;
using Application.Service.AbilityServices.ResourceCostTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Moq;
using Xunit;

namespace Unit.Test.ResourceCostType;

public class UpdateResourceCostTypeCommandHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IResourceCostTypeService> _resourceCostTypeServiceMock;
    private readonly Mock<IResourceCostTypeRepository> _resourceCostTypeRepositoryMock;
    private readonly Mock<ResourceCostTypeBusinessRules> _resourceCostTypeBusinessRulesMock;

    public UpdateResourceCostTypeCommandHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _resourceCostTypeBusinessRulesMock = new Mock<ResourceCostTypeBusinessRules>();
        _resourceCostTypeServiceMock = new Mock<IResourceCostTypeService>();
        _resourceCostTypeRepositoryMock = new Mock<IResourceCostTypeRepository>();
    }


    [Theory]
    [InlineData("65e6071da3101fa3c673ef32", "Ann")]
    public async Task ResourceCostTypeHandler_ValidRequest_ReturnsResponse(string id, string name)
    {
        var businessRuleMock = new Mock<ResourceCostTypeBusinessRules>(_resourceCostTypeRepositoryMock.Object);

        var handler = new UpdateResourceCostTypeCommandHandler(_mapperMock.Object, _resourceCostTypeServiceMock.Object,businessRuleMock.Object);

        var request = new UpdateResourceCostTypeCommandRequest
        {
            UpdateResourcesCostTypeDto = new UpdateResourcesCostTypeDto
            {
                Id = id,
                Name = name,
            }
        };

        var expectedResourceCostType = new Domain.Abilities.ResourceCostType
        {
            Id = id,
            Name = "xxxxxxxxxx",
            Code = "19805-GBIT-272",
            Status = true,
            IsDeleted = false
        };

        var expectedResponse = new UpdateResourceCostTypeCommandResponse
        {
            Id = id,
            Name = name,
            Code = "19805-GBIT-272",
            Status = true,
            IsDeleted = false,
        };

        _mapperMock.Setup(m => m.Map<Domain.Abilities.ResourceCostType>(request.UpdateResourcesCostTypeDto))
                   .Returns(expectedResourceCostType);

        _resourceCostTypeServiceMock.Setup(m => m.GetById(id))
                                    .ReturnsAsync(expectedResourceCostType);

        _resourceCostTypeServiceMock.Setup(m => m.Update(expectedResourceCostType))
                                    .ReturnsAsync(expectedResourceCostType);

        _mapperMock.Setup(m => m.Map<UpdateResourceCostTypeCommandResponse>(expectedResourceCostType))
                   .Returns(expectedResponse);


        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.Name, response.Name);

        _resourceCostTypeServiceMock.Verify(m => m.Update(expectedResourceCostType), Times.Once);
    }


}

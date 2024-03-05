using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Update;
using Application.Feature.AbilityFeatures.CastTimeTypes.Dtos;
using Application.Feature.AbilityFeatures.CastTimeTypes.Rules;
using Application.Service.AbilityServices.CastTimeTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Moq;
using Xunit;

namespace Unit.Test.CastTimeTypes;

public class UpdateCastTimeTypesCommandHandlerTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<ICastTimeTypeService> _resourceCastTimeTypeServiceMock;
    private readonly Mock<ICastTimeTypeRepository> _resourceCastTimeTypeRepositoryMock;
    private readonly Mock<CastTimeTypeBusinessRules> _resourceCastTimeTypeBusinessRulesMock;

    public UpdateCastTimeTypesCommandHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _resourceCastTimeTypeBusinessRulesMock = new Mock<CastTimeTypeBusinessRules>();
        _resourceCastTimeTypeServiceMock = new Mock<ICastTimeTypeService>();
        _resourceCastTimeTypeRepositoryMock = new Mock<ICastTimeTypeRepository>();
    }



    [Theory]
    [InlineData("65e6071da3101fa3c673ef32", "xxx", "xxxxxxx")]
    public async Task CastTimeTypesHandler_ValidRequest_ReturnsResponse(string id, string name, string description)
    {
        var businessRuleMock = new Mock<CastTimeTypeBusinessRules>(_resourceCastTimeTypeRepositoryMock.Object);

        var handler = new UpdateCastTimeTypeCommandHandler(
            _resourceCastTimeTypeServiceMock.Object,
            businessRuleMock.Object,
            _mapperMock.Object
        );

        var request = new UpdateCastTimeTypeCommandRequest
        {
            UpdateCastTimeTypeDto = new UpdateCastTimeTypeDto
            {
                Id = id,
                Name = name,
                Description = description
            }
        };

        var expectedCastTimeTypes = new Domain.Abilities.CastTimeType
        {
            Id = id,
            Name = name,
            Description = description,
            
        };

        var expectedResponse = new UpdateCastTimeTypeCommandResponse
        {
            Id = id,
            Name = name,
            Description = description,
        };

        _mapperMock.Setup(m => m.Map<Domain.Abilities.CastTimeType>(request.UpdateCastTimeTypeDto))
                   .Returns(expectedCastTimeTypes);

        _resourceCastTimeTypeServiceMock.Setup(m => m.GetById(id))
                                    .ReturnsAsync(expectedCastTimeTypes);

        _resourceCastTimeTypeServiceMock.Setup(m => m.Update(expectedCastTimeTypes))
                                    .ReturnsAsync(expectedCastTimeTypes);

        _mapperMock.Setup(m => m.Map<UpdateCastTimeTypeCommandResponse>(expectedCastTimeTypes))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse, response);

        _resourceCastTimeTypeServiceMock.Verify(m => m.Update(expectedCastTimeTypes), Times.Once);

    }

}

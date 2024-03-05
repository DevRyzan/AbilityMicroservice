using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.Remove;
using Application.Feature.AbilityFeatures.CastTimeTypes.Commands.UndoDelete;
using Application.Feature.AbilityFeatures.CastTimeTypes.Dtos;
using Application.Feature.AbilityFeatures.CastTimeTypes.Rules;
using Application.Service.AbilityServices.CastTimeTypeService;
using Application.Service.Repositories;
using AutoMapper;
using Moq;
using Xunit;

namespace Unit.Test.CastTimeTypes;

public class UndoDeleteCastTimeTypesCommandHandlerTest
{

    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<ICastTimeTypeService> _resourceCastTimeTypeServiceMock;
    private readonly Mock<ICastTimeTypeRepository> _resourceCastTimeTypeRepositoryMock;
    private readonly Mock<CastTimeTypeBusinessRules> _resourceCastTimeTypeBusinessRulesMock;

    public UndoDeleteCastTimeTypesCommandHandlerTest()
    {
        _mapperMock = new Mock<IMapper>();
        _resourceCastTimeTypeBusinessRulesMock = new Mock<CastTimeTypeBusinessRules>();
        _resourceCastTimeTypeServiceMock = new Mock<ICastTimeTypeService>();
        _resourceCastTimeTypeRepositoryMock = new Mock<ICastTimeTypeRepository>();
    }



    [Theory]
    [InlineData("65e6071da3101fa3c673ef32")]
    public async Task CastTimeTypesHandler_ValidRequest_ReturnsResponse(string id)
    {
        var businessRuleMock = new Mock<CastTimeTypeBusinessRules>(_resourceCastTimeTypeRepositoryMock.Object);

        var handler = new UndoDeleteCastTimeTypeCommandHandler(
            _resourceCastTimeTypeServiceMock.Object,
            businessRuleMock.Object,
            _mapperMock.Object
        );

        var request = new UndoDeleteCastTimeTypeCommandRequest
        {
            UndoDeleteCastTimeTypeDto = new UndoDeleteCastTimeTypeDto
            {
                Id = id
            }
        };

        var expectedCastTimeTypes = new Domain.Abilities.CastTimeType
        {
            Id = id,
            Status = false,
            IsDeleted = true
        };

        var expectedResponse = new UndoDeleteCastTimeTypeCommandResponse
        {
            Id = id,
            Status = false,
            IsDeleted = false,
        };

        _mapperMock.Setup(m => m.Map<Domain.Abilities.CastTimeType>(request.UndoDeleteCastTimeTypeDto))
                   .Returns(expectedCastTimeTypes);

        _resourceCastTimeTypeServiceMock.Setup(m => m.GetById(id))
                                    .ReturnsAsync(expectedCastTimeTypes);

        _resourceCastTimeTypeServiceMock.Setup(m => m.Update(expectedCastTimeTypes))
                                    .ReturnsAsync(expectedCastTimeTypes);

        _mapperMock.Setup(m => m.Map<UndoDeleteCastTimeTypeCommandResponse>(expectedCastTimeTypes))
                   .Returns(expectedResponse);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.Equal(expectedResponse.IsDeleted, response.IsDeleted);

        _resourceCastTimeTypeServiceMock.Verify(m => m.Update(expectedCastTimeTypes), Times.Once);

    }

}

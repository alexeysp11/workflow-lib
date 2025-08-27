using Grpc.Core;
using Moq;
using WorkflowLib.DataStorage.Core.Tables;
using WorkflowLib.DataStorage.InMemoryService.Grpc.Services;
using WorkflowLib.DataStorage.Models;

namespace WorkflowLib.DataStorage.InMemoryService.Grpc.Tests;

public class InMemoryStorageServiceTests
{
    private readonly InMemoryStorageService _service;
    private readonly AppSettings _appSettings;
    private readonly InMemoryHashTable<string, string> _inMemoryData;

    public InMemoryStorageServiceTests()
    {
        _inMemoryData = new InMemoryHashTable<string, string>();
        _appSettings = new AppSettings { EnvironmentVariable = "Production" };
        _service = new InMemoryStorageService(_appSettings, _inMemoryData);
    }

    [Fact]
    public async Task Save_ValidRequest_SavesData()
    {
        // Arrange
        var request = new SaveRequest { Key = "testKey", Value = "testValue" };

        // Act
        var context = TestServerCallContext.Create();
        var response = await _service.Save(request, context);

        // Assert
        Assert.True(response.Success);
        // Assert.True(_inMemoryData.ContainsKey("testKey"));
        Assert.Equal("testValue", _inMemoryData.SearchElement("testKey"));
    }

    [Fact]
    public async Task Search_KeyExists_ReturnsValue()
    {
        // Arrange
        _inMemoryData.AddElement("existingKey", "existingValue");
        var request = new SearchRequest { Key = "existingKey" };

        // Act
        var context = TestServerCallContext.Create();
        var response = await _service.Search(request, context);

        // Assert
        Assert.True(response.Found);
        Assert.Equal("existingValue", response.Value);
    }
}

public static class TestServerCallContext
{
    public static ServerCallContext Create()
    {
        var mockContext = new Mock<ServerCallContext>();
        return mockContext.Object;
    }
}

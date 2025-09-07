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

    [Fact]
    public async Task IncrementElement_NonExistingKey_ReturnsZero()
    {
        // Arrange
        string key = "incrementNonExistingKey";
        var incrementRequest = new IncrementRequest { Key = key };
        var searchRequest = new SearchRequest { Key = key };

        // Act
        var context = TestServerCallContext.Create();
        var incrementResult = await _service.Increment(incrementRequest, context);
        var searchResponse = await _service.Search(searchRequest, context);

        // Assert
        Assert.Equal(0, incrementResult.Value);
        Assert.Equal("0", searchResponse.Value);
        Assert.True(incrementResult.Success);
    }

    [Fact]
    public async Task IncrementElement_ExistingKeyCorrectType_ReturnsIncremented()
    {
        // Arrange
        string key = "incrementExistingKeyCorrectType";
        int value = 1;
        int expected = value + 1;
        var saveRequest = new SaveRequest { Key = key, Value = value.ToString() };
        var incrementRequest = new IncrementRequest { Key = key };
        var searchRequest = new SearchRequest { Key = key };

        // Act
        var context = TestServerCallContext.Create();
        var saveResponse = await _service.Save(saveRequest, context);
        var incrementResult = await _service.Increment(incrementRequest, context);
        var searchResponse = await _service.Search(searchRequest, context);

        // Assert
        Assert.Equal(expected, incrementResult.Value);
        Assert.Equal(expected.ToString(), searchResponse.Value);
        Assert.True(incrementResult.Success);
    }

    [Fact]
    public async Task IncrementElement_ExistingKeyStringType_ReturnsNull()
    {
        // Arrange
        string key = "incrementExistingKeyStringType";
        string value = "Test";
        var saveRequest = new SaveRequest { Key = key, Value = value };
        var incrementRequest = new IncrementRequest { Key = key };
        var searchRequest = new SearchRequest { Key = key };

        // Act
        var context = TestServerCallContext.Create();
        var saveResponse = await _service.Save(saveRequest, context);
        var incrementResult = await _service.Increment(incrementRequest, context);
        var searchResponse = await _service.Search(searchRequest, context);

        // Assert
        Assert.Equal(value, searchResponse.Value);
        Assert.Null(incrementResult.Value);
        Assert.False(incrementResult.Success);
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

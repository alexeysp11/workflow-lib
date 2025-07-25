using System.Collections.Generic;
using System.Reflection;
using FileMqBroker.Tests.MqLibrary.Attributes;
using FileMqBroker.Tests.MqLibrary.Mocks.DAL;
using FileMqBroker.Tests.MqLibrary.TestCases;
using FileMqBroker.MqLibrary.Models;

namespace FileMqBroker.Tests.MqLibrary.TestCases.DAL;

/// <summary>
/// 
/// </summary>
public class TestMockMessageFileDAL : ITestCase
{
    private MockMessageFileDAL _mockMessageFileDAL;

    /// <summary>
    /// 
    /// </summary>
    public TestMockMessageFileDAL()
    {
        _mockMessageFileDAL = new MockMessageFileDAL();
    }

    /// <summary>
    /// 
    /// </summary>
    public void RunTests()
    {
        var methods = GetType().GetMethods()
            .Where(x => x.GetCustomAttributes(typeof(MqLibraryTestMethodAttribute), false).Length > 0)
            .ToArray();
        
        foreach (var method in methods)
        {
            method.Invoke(this, null);
        }
    }

    [MqLibraryTestMethod]
    public void InsertMessageFileState_EmptyList_NoOutput()
    {
        var method = MethodBase.GetCurrentMethod();
        System.Console.WriteLine($"= {method.ReflectedType.Name}.{method.Name}");

        var files = new List<MessageFile>();
        _mockMessageFileDAL.InsertMessageFileState(files);
    }

    [MqLibraryTestMethod]
    public void InsertMessageFileState_OneElementInList()
    {
        var method = MethodBase.GetCurrentMethod();
        System.Console.WriteLine($"= {method.ReflectedType.Name}.{method.Name}");

        var files = new List<MessageFile>
        {
            new MessageFile
            {
                Name = "Custom name"
            }
        };
        _mockMessageFileDAL.InsertMessageFileState(files);
    }
}
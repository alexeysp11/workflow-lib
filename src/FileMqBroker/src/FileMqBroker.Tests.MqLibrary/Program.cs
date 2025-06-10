using FileMqBroker.Tests.MqLibrary.TestCases;
using FileMqBroker.Tests.MqLibrary.TestCases.DAL;

var testCases = new List<ITestCase>
{
    new TestMockMessageFileDAL()
};

foreach (var testCase in testCases)
{
    testCase.RunTests();
}

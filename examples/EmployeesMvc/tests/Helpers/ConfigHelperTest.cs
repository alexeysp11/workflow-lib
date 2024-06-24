using Xunit;
using WorkflowLib.Examples.EmployeesMvc.Models;
using WorkflowLib.Examples.EmployeesMvc.Helpers;

namespace Tests.WorkflowLib.Examples.EmployeesMvc;

public class ConfigHelperTest
{
    [Fact]
    public void VacationQty()
    {
        Assert.True(ConfigHelper.EmployeeQty * ConfigHelper.VacationIntervals.Length == ConfigHelper.VacationQty); 
    }
}
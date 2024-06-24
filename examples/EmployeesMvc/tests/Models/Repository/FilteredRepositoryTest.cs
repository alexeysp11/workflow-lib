using System; 
using Xunit;
using WorkflowLib.Examples.EmployeesMvc.Models;

namespace Tests.WorkflowLib.Examples.EmployeesMvc;

public class FilteredRepositoryTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void GetFiltered_IncorrectUid_ThrowsException(string uid)
    {
        // Arrange 
        var employees = new FilteredRepository<Employee>();
        var vacations = new FilteredRepository<Vacation>();

        // Act 
        Action actEmployees = () => employees.GetFiltered(uid); 
        Action actVacations = () => vacations.GetFiltered(uid); 

        // Assert 
        System.Exception exceptionEmployees = Assert.Throws<System.Exception>(actEmployees);
        System.Exception exceptionVacations = Assert.Throws<System.Exception>(actVacations);
    }
}
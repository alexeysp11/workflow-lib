using System;
using Xunit;
using WorkflowLib.Shared.Models.Business.InformationSystem;
using WorkflowLib.Examples.EmployeesMvc.Core.Repositories;

namespace Tests.WorkflowLib.Examples.EmployeesMvc.Core.Repositories;

public class FilteredRepositoryTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void GetFiltered_IncorrectUid_ThrowsException(string uid)
    {
        // Arrange 
        var employees = new FilteredRepository<Employee>(SettingsHelper.AppSettings);
        var vacations = new FilteredRepository<Absense>(SettingsHelper.AppSettings);

        // Act 
        Action actEmployees = () => employees.GetFiltered(uid);
        Action actVacations = () => vacations.GetFiltered(uid);

        // Assert 
        System.Exception exceptionEmployees = Assert.Throws<System.Exception>(actEmployees);
        System.Exception exceptionVacations = Assert.Throws<System.Exception>(actVacations);
    }
}
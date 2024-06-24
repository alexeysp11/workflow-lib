using System.Linq; 
using Xunit;
using WorkflowLib.Examples.EmployeesMvc.Models;
using WorkflowLib.Examples.EmployeesMvc.Helpers;

namespace Tests.WorkflowLib.Examples.EmployeesMvc;

public class UnitOfWorkTest
{
    [Fact]
    public void Constructor_NoParameters_CorrectNumberOfGeneratedElements()
    {
        // Arrange
        var unitOfWork = new UnitOfWork(); 

        // Act 
        var employees = unitOfWork.GetEmployees(); 
        var vacations = unitOfWork.GetVacations(); 

        // Assert 
        Assert.Equal(employees.Count, ConfigHelper.EmployeeQty); 
        Assert.Equal(vacations.Count, ConfigHelper.VacationQty); 
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("IncorrectFullnameOfTheEmployee")]
    public void InsertVacation_IncorrectFio_RecordIsNotInserted(string fio)
    {
        // Arrange
        var unitOfWork = new UnitOfWork(); 
        var beginDate = System.DateTime.Now; 
        var endDate = beginDate.AddDays(14); 

        // Act 
        unitOfWork.InsertVacation(fio, beginDate, endDate); 
        var vacations = unitOfWork.GetVacations(); 
        var isInserted = vacations.Where(x => 
                x.Employee.FIO == fio 
                && x.BeginDate == beginDate 
                && x.EndDate == endDate)
            .ToList().Count > 0; 

        // Assert 
        Assert.False(isInserted); 
        Assert.Equal(vacations.Count, ConfigHelper.VacationQty); 
    }

    [Fact]
    public void InsertVacation_CorrectParameters_OnlyOneRecordWasInsertedAndTotalQtyIncrementedByOne()
    {
        // Arrange
        var unitOfWork = new UnitOfWork(); 
        var beginDate = System.DateTime.Now; 
        var endDate = beginDate.AddDays(14); 
        var fio = unitOfWork.GetVacations().First().Employee.FIO; 

        // Act 
        unitOfWork.InsertVacation(fio, beginDate, endDate); 
        var vacations = unitOfWork.GetVacations(); 
        var isInserted = vacations.Where(x => 
                x.Employee.FIO == fio 
                && x.BeginDate == beginDate 
                && x.EndDate == endDate)
            .ToList().Count == 1; 

        // Assert 
        Assert.True(isInserted); 
        Assert.Equal(vacations.Count, ConfigHelper.VacationQty + 1); 
    }
}
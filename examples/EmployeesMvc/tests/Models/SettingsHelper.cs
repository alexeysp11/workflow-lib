using WorkflowLib.Examples.EmployeesMvc.Core.Models.Configurations;

namespace Tests.WorkflowLib.Examples.EmployeesMvc;

internal static class SettingsHelper
{
    internal static AppSettings AppSettings { get; }

    static SettingsHelper()
    {
        AppSettings = new AppSettings
        {
            DbSetCollectorInterval = 20000,
            EmployeeQty = 100,
            VacationIntervals = new int[] { 14, 7, 7 },
            EmployeeMaxAge = 70,
            EmployeeMinAge = 18,
            EmployeeFullNameLength = 10,
            EmployeeFullNameWordsNumber = 3,

            StringSettings = new StringSettings
            {
                TempDataSettings = new TempDataSettings
                {
                    EmployeesUidStr = "employeesUid",
                    VacationsUidStr = "vacationsUid",
                    FilterInfoEmployeesStr = "filterInfoEmployees",
                    FilterInfoVacationsStr = "filterInfoVacations",
                    EmployeeInfoVacationsStr = "employeeInfoVacations",
                    FilterOptionsEmployeesStr = "filterOptionsEmployees",
                    FilterOptionsVacationsStr = "filterOptionsVacations"
                },
                FilterOptionsSettings = new FilterOptionsSettings
                {
                    NoFiltersApplied = "No filters applied",
                    FindFilterOptionsShowEmployee = "Show employee",
                    FindFilterOptionsExcludeEmployee = "Exclude employee",
                    FindFilterOptionsShowAllFilteredVacations = "Find all filtered vacations",
                    FindFilterOptionsShowIntersections = "Show intersections",
                    FindFilterOptionsExcludeIntersections = "Exclude intersections"
                }
            }
        };
    }
}
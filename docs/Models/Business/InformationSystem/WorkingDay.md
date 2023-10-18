# WorkingDay Class 

*Namespace*: [Cims.WorkflowLib.Models.Business.InformationSystem](Cims.WorkflowLib.Models.Business.InformationSystem.md)

*Implements*: [IBusinessEntityWF](../IBusinessEntityWF.md)

*Inherits*: [BusinessEntityWF](../BusinessEntityWF.md)

The Scheduler module is organizing the Employees work time and place. Work places are the company Projects. For each day for each Employee is created Schedule which keeps track of all needed information. The Schedule module also provides way for calculating Paychecks for the Employees. To be make this possible to each Employee is assigned Pay Rate.

## Properties 

Date - The scheduling date.
Is Holiday - Indicates if the the scheduling date is holiday.
Is Paid Day Off - Indicates if the the scheduling date is pay day off.
Is Unpaid Day Off - Indicates if the the scheduling date is unpaid day off.
Is Sick Day Off - Indicates if the the scheduling date is sick day off.
Work Hours - Number of work hours - most likely to be 8.
Extra Work Hours - Extra work hours for the day.
Employee - The scheduled employee.
Project - The scheduled company project.

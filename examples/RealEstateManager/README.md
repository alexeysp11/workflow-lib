# RealEstateManager 

## Prerequisites 

- MS SQL Server; 
- SQL Server Management Studio. 

## Configuration 

In order to make migration for the first time, open up command line and run the following commands: 

```
cd database 
dotnet ef --startup-project ../api/RealEstateManager.csproj migrations add InitialCreate
dotnet ef --startup-project ../api/RealEstateManager.csproj database update
cd ..
```

The tables will be filled with data after first launch of the application. 

So you can open **SQL Server Management Studio** and check if the tables are created: 
```SQL
select * from RealEstate.dbo.Properties; 
select * from RealEstate.dbo.Payments; 
select * from RealEstate.dbo.__EFMigrationsHistory; 
```

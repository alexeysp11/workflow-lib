# PgDbConnection

`PgDbConnection` is a class for using PostgreSQL database.

Namespace: [Cims.WorkflowLib.DbConnections](Cims.WorkflowLib.DbConnections.md)

## Constructors 

### PgDbConnection(String)

Initializes a new instance of the `PgDbConnection` class with the specified connection string.

```C#
public PgDbConnection(string path);
```

#### Parameters 

- `path`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

The specified connection string. 

## Methods

### ExecuteSqlCommand(String)

Executes SQL string and returns [DataTable](https://learn.microsoft.com/en-us/dotnet/api/system.data.datatable).

```C#
public DataTable ExecuteSqlCommand(string sqlRequest);
```

#### Parameters 

- `sqlRequest`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Specified SQL query.

#### Returns 

[DataTable](https://learn.microsoft.com/en-us/dotnet/api/system.data.datatable)

A [DataTable](https://learn.microsoft.com/en-us/dotnet/api/system.data.datatable) that contains result of the executed SQL query.

#### Examples 

Example of using `PgDbConnection.ExecuteSqlCommand()`:
```C#
ICommonDbConnection dbConncection = new PgDbConnection("PathToDb/yourdb.db");
var dt = dbConncection.ExecuteSqlCommand("select id, name from your_table;");
```

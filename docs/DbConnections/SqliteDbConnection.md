# SqliteDbConnection Class

Namespace: [Cims.WorkflowLib.DbConnections](Cims.WorkflowLib.DbConnections.md)

`SqliteDbConnection` is a class for using SQLite database.

## Constructors 

### SqliteDbConnection(String)

Initializes a new instance of the `SqliteDbConnection` class with the specified database path.

```C#
public SqliteDbConnection(string path);
```

#### Parameters 

- `path`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

The specified database path (connection string). 

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

Example of using `SqliteDbConnection.ExecuteSqlCommand()`:
```C#
ICommonDbConnection dbConncection = new SqliteDbConnection("PathToDb/yourdb.db");
var dt = dbConncection.ExecuteSqlCommand("select id, name from your_table;");
```

# MysqlDbConnection Class

Namespace: [Cims.WorkflowLib.DbConnections](Cims.WorkflowLib.DbConnections.md)

`MysqlDbConnection` is a class for using MySQL database.

## Constructors 

### MysqlDbConnection(String)

Initializes a new instance of the `MysqlDbConnection` class with the specified connection string.

```C#
public MysqlDbConnection(string path);
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

Example of using `MysqlDbConnection.ExecuteSqlCommand()`:
```C#
ICommonDbConnection dbConncection = new MysqlDbConnection("CONNECTION_STRING");
var dt = dbConncection.ExecuteSqlCommand("select id, name from your_table;");
```

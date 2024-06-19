# ChatCsharp 

[English](README.md) | [Русский](README.ru.md)

The application is a simple client-server chat written in `C#`. 

It consists of two projects: a client-side app written using **WPF** and **MVVM** pattern, and a server-side app written as a console app.

## Description 

The project description is presented at [this link](Docs/Description.md).

### Goals 

The goals of the project are to create a basic chat application that allows users to communicate with each other through a server.

### Scope

The scope of the project is limited to the development of the client-side and server-side applications required for the chat functionality.

### Who can use this app

The application can be used by anyone who needs a basic chat functionality, such as small businesses or individuals who need to communicate with others remotely.

### Main functionalities

The main functionalities the chat should have include sending and receiving messages, displaying online users, and handling multiple connections to the server.

## Techonologies 

- .NET frameworks:
    - .NET Core 3.1 (C# 8)
    - .NET 6 (C# 10)
- Databases: 
    - [SQLite](https://github.com/sqlite/sqlite)
    - [PostgreSQL](https://www.postgresql.org/)
- External services (libraries): 
    - [workflow-auth](https://github.com/alexeysp11/workflow-auth)
    - [workflow-lib](https://github.com/alexeysp11/workflow-lib)
- [Swagger](https://swagger.io/tools/swagger-ui)

## How to use 

### Prerequisites

- Windows OS;
- .NET Core 3.1;
- Any text editor (*VS Code*, *Sublime Text*, *Notepad++* etc) or Visual Studio;
- Windows command line (if you do not use Visual Studio).

Dependencies for this application:

- `System.Net.Sockets` for *Socket Programming*;
- `Microsoft.Data.Sqlite` for *SQLite Database*; 
- `System.ComponentModel.INotifyPropertyChanged` for *reporting changes to UI*; 
- `System.Windows.Input.ICommand` for *commands* implementation; 
- `System.IDisposable` for *GC*. 

In order to get the application, run the following command in the CMD:
```
git clone https://github.com/alexeysp11/workflow-auth.git
git clone https://github.com/alexeysp11/workflow-lib.git
git clone https://github.com/alexeysp11/ChatCsharp.git
```

## Code snippets 

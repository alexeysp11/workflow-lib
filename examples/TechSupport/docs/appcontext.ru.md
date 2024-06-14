# appcontext

[English](appcontext.md) | [Русский](appcontext.ru.md)

## Сохранение контекста в рантайме

В композитных приложениях лучше всего сохранять контекст внутри каждого приложения в рантайме. 
Это позволяет пользователям переключаться между приложениями без потери данных сеанса.

Это можно добиться с помощью такого рода объектной модели:

```C#
public interface IAppContext
{
    AuthenticationContext AuthenticationContext { get; set; }
    UserContext UserContext { get; set; }
    ApplicationContext ApplicationContext { get; set; }
}

public class CustomersAppContext : IAppContext
{
    public AuthenticationContext AuthenticationContext { get; set; }
    public UserContext UserContext { get; set; }
    public ApplicationContext ApplicationContext { get; set; }

    public Customer CurrentCustomer { get; set; }
}

public class NotificationsAppContext : IAppContext
{
    public AuthenticationContext AuthenticationContext { get; set; }
    public UserContext UserContext { get; set; }
    public ApplicationContext ApplicationContext { get; set; }

    public int UnreadNotificationsCount { get; set; }
}

public class EventJournalAppContext : IAppContext
{
    public AuthenticationContext AuthenticationContext { get; set; }
    public UserContext UserContext { get; set; }
    public ApplicationContext ApplicationContext { get; set; }

    public Event CurrentEvent { get; set; }
}

public class ApplicationContext
{
    public string CurrentPage { get; set; }
    public string ActiveTab { get; set; }
    public Dictionary<string, object> Data { get; set; }
}

public class AuthenticationContext
{
    public string UserName { get; set; }
    public string Role { get; set; }
    public string AccessToken { get; set; }
}

public class UserContext
{
    public string Name { get; set; }
    public string Email { get; set; }
    public Dictionary<string, string> Settings { get; set; }
}
```

## Необходимость функции сохранения контекста в несложных приложениях

Функция сохранения контекста важна даже для несложных приложений, включенных в состав композитного приложения. 
Она обеспечивает плавный пользовательский интерфейс и предотвращает потерю данных, когда пользователь переключается между приложениями.

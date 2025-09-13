# WorkflowLib.Shared.WpfExtensions

[English](README.md) | [Русский](README.ru.md)

`WorkflowLib.Shared.WpfExtensions` - это библиотека визуальных компонентов для WPF-приложений.

## Auth

```C#
void toLoginBtn_Click(object sender, RoutedEventArgs e)
{
    Login a = new Login();
    Close();
    a.ShowDialog();
}

void toRegisterBtn_Click(object sender, RoutedEventArgs e)
{
    Registration a = new Registration();
    Close();
    a.ShowDialog();
}
```

# WpfExtensions

[English](README.md) | [Русский](README.ru.md)

`WpfExtensions` is a library of visual elements for WPF applications. 

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

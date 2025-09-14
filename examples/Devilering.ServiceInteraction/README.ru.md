# ServiceInteraction

[English](README.md) | [Русский](README.ru.md)

Есть несколько компонентов, которые "общаются" между собой, как представлено на рисунке ниже.

![ServiceInteraction](../../docs/img/examples/ServiceInteraction.png)

Ксательно коммуникации между компонентами можно выделить несколько пунктов:
- Компоненты коммуницируют не напрямую, а через библиотеку [ServiceDiscoveryBpm](../../../src/Shared/ServiceDiscoveryBpm/README.ru.md).
- Детали коммуникации с БД реализуются на стороне приложения, реализующего бизнес-логику.

Имеется несколько видов клиентских приложений:
- монолит;
- HTTP;
- gRPC.

## Последовательность обработки запросов на сервисах

### Customer

![ServiceInteraction_CustomerService](../../docs/img/examples/ServiceInteraction_CustomerService.png)

## Конфигурация проектов

1. В базе данных PostgreSQL создать базу с именем `deliveryservicelibexample`.

2. Выполнить команду для обновления базы данных на основе миграций.

```
dotnet ef database update --project BL/VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.csproj --startup-project InitializeDb/VelocipedeUtils.Examples.Delivering.ServiceInteraction.InitializeDb.csproj
```

3. Заполнить базу данных тестовыми данными: запустить консольное приложение `InitializeDb`.

4. После удачного выполнения консольного приложения `InitializeDb`, подкорректировать файл [Customer.MakeOrder.json](JsonRequestTemplates\Customer.MakeOrder.json): параметр `productIds` должен иметь ИД записей, которые соответствуют первым 3 продуктам. Данный файл используется для тестирования АПИ при заведении заказа на стороне потребителя (например, приложение [WebAPI customer](Webapi/customer/README.ru.md)).

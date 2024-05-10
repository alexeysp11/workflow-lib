# ServiceInteraction

[English](README.md) | [Русский](README.ru.md)

Есть несколько компонентов, которые "общаются" между собой, как представлено на рисунке ниже.

![ServiceInteraction](../../../docs/img/examples/ServiceInteraction.png)

Ксательно коммуникации между компонентами можно выделить несколько пунктов:
- Компоненты коммуницируют не напрямую, а через библиотеку [ServiceDiscoveryBpm](../../../src/ServiceDiscoveryBpm/README.ru.md).
- Детали коммуникации с БД реализуются на стороне приложения, реализующего бизнес-логику.

Имеется несколько видов клиентских приложений:
- монолит;
- HTTP;
- gRPC.

## Последовательность обработки запросов на сервисах

### Customer

![ServiceInteraction_CustomerService](../../../docs/img/examples/ServiceInteraction_CustomerService.png)

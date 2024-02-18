# ServiceInteraction

[English](README.md) | [Русский](README.ru.md)

Представим, что есть несколько компонентов, которые "общаются" между собой, как представлено на рисунке ниже.

![ServiceInteraction](../../docs/img/examples/ServiceInteraction.png)

Ксательно реализации компонентов и коммуникации между ними есть несколько пунктов:
- эти компоненты реализованы в виде классов в библиотеке C#;
- компоненты коммуницируют не напрямую, а через "ресолвер": 
    - "ресолвер" обращается к БД для того, чтобы получить информацию о типе взаимодействия.

Имеется несколько видов оболочек:
- монолит;
- HTTP;
- gRPC.

![ExplicitImplicitCall](../../docs/img/examples/ExplicitImplicitCall.png)
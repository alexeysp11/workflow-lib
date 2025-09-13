# WorkflowLib.Shared.Models.Business

[English](README.md) | [Русский](README.ru.md)

Данный проект является реализацией общей объектной модели для бизнес-сущностей, используемых в рамках [workflow-lib](https://github.com/alexeysp11/workflow-lib).

## Идея

Библиотека [workflow-lib](https://github.com/alexeysp11/workflow-lib) создана для решения проблемы дублирования кода и разрозненности объектных моделей при разработке бизнес-приложений. Например, ранее у меня часто возникала необходимость создания идентичных сущностей и сервисов в разных проектах, что приводило к потере времени и усложняло поддержку. Стоит отметить, что у каждого проекта был свой репозиторий, что усложняло интеграцию между проектами и возможность изменения объектной модели.

В результате, было принято решение о создании монорепозитория, куда вошла большая часть ранее созданных проектов, а также общая объектная модель для представления данных в БД. Такой подход позволяет:
- Избежать дублирования кода.
- Обеспечить консистентность данных между проектами.
- Сократить время разработки за счет повторного использования готовых компонентов.
- Упростить рефакторинг и управление зависимостями.

Проект `WorkflowLib.Shared.Models.Business` содержит общую объектную модель для бизнес-сущностей.

## Примеры классов

Данная часть библиотеки предоставляет классы для бизнеса:
- Общее: [бизнес-задача](BusinessTask.cs), [риск](Risk.cs), etc.
- Бизнес-документы: [счёт](BusinessDocuments/Bill.cs), [заказ на доставку](BusinessDocuments/DeliveryOrder.cs), [трудовой договор](BusinessDocuments/EmploymentContract.cs), etc.
- Потербители: [потребитель](Customers/Customer.cs), [компания](Customers/Company.cs), [contact](Customers/Contact.cs), etc.
- Информационная система: [работник](InformationSystem/Employee.cs), [аккаунт пользователя](InformationSystem/UserAccount.cs), [рабочий день](InformationSystem/WorkingDay.cs), etc.
- Деньги: [зарплата/чек оплаты](Monetary/Paycheck.cs), [оплата](Monetary/Payment.cs), [ставка оплаты](Monetary/PayRate.cs), etc.
- Продукты: [продукт](Products/Product.cs), [категория продукта](Products/ProductCategory.cs), [проект](Products/Project.cs).
- Обязанности: [обязанности работника](Responsibilities/EmployeeResponsibility.cs), [обязанности работодателя](Responsibilities/EmployerResponsibility.cs).
- Социальное общение: [сообщение](SocialCommunication/MessageWF.cs).

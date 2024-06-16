# Models.Business

[English](README.md) | [Русский](README.ru.md)

Библиотека включает в себя несколько классов для бизнеса, таких как общие модели данных, такие как адрес, бизнес-операция, период, риск и т.д.
Он также включает классы для деловых документов, таких как счет, заказ на доставку, трудовой договор, клиенты, такие как клиент, компания, контакт, информационная система, такая как сотрудник, учетная запись пользователя, рабочий день, денежные модели, такие как зарплата, оплата, ставка заработной платы и продукты, такие как продукт, продукт. категория, проект.
Кроме того, в библиотеке предусмотрены занятия по таким обязанностям, как ответственность сотрудников, ответственность работодателя и социальное общение, например сообщения.

Данная часть библиотеки предоставляет классы для бизнеса:
- Общее: [бизнес-задача](BusinessTask.cs), [риск](Risk.cs), etc.
- Бизнес-документы: [счёт](BusinessDocuments/Bill.cs), [заказ на доставку](BusinessDocuments/DeliveryOrder.cs), [трудовой договор](BusinessDocuments/EmploymentContract.cs), etc.
- Потербители: [потребитель](Customers/Customer.cs), [компания](Customers/Company.cs), [contact](Customers/Contact.cs), etc.
- Информационная система: [работник](InformationSystem/Employee.cs), [аккаунт пользователя](InformationSystem/UserAccount.cs), [рабочий день](InformationSystem/WorkingDay.cs), etc.
- Деньги: [зарплата/чек оплаты](Monetary/Paycheck.cs), [оплата](Monetary/Payment.cs), [ставка оплаты](Monetary/PayRate.cs), etc.
- Продукты: [продукт](Products/Product.cs), [категория продукта](Products/ProductCategory.cs), [проект](Products/Project.cs).
- Обязанности: [обязанности работника](Responsibilities/EmployeeResponsibility.cs), [обязанности работодателя](Responsibilities/EmployerResponsibility.cs).
- Социальное общение: [сообщение](SocialCommunication/MessageWF.cs).

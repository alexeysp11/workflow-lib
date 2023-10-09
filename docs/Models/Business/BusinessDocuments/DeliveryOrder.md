# DeliveryOrder Class

Namespace: [Cims.WorkflowLib.Models.Business.BusinessDocuments](Cims.WorkflowLib.Models.Business.BusinessDocuments.md)

- **Delivery order** - заказ на доставку (наименование: `DeliveryOrder`):
    - `OrderUid: string` - UID заказа,
    - `OpenOrderDt: DateTime` - фактическое время оформления заказа,
    - `CloseOrderDt: DateTime` - фактическое время закрытия заказа,
    - `UserUid: string` - UID пользователя,
    - `DeliveryMethod: DeliveryMethod` - способ доставки,
    - `CookingOperation: BusinessOperation` - операция готовки,
    - `DeliveryOperation: BusinessOperation` - операция доставки,
    - `Products: List<Product>` - список выбранных продуктов,
    - `ProductsPrice: float` - общая цена выбранных продуктов,
    - `DeliveryPrice: float` - цена доставки,
    - `TotalPrice: float` - общая цена заказа,
    - `Origin: Address` - место доставки,
    - `Destination: Address` - место доставки,
    - `Payments: List<Payment>` - оплата (технически возможно несколько оплат, например, с исопльзованием [Split payment](https://en.wikipedia.org/wiki/Split_payment), поэтому количество оплат должно регулироваться на стороне клиентского приложения),
    - `Status: string` - статус.

using AwesomeShop.Domain.Enums;
using AwesomeShop.Domain.Events;
using AwesomeShop.Domain.ValueObjects;

namespace AwesomeShop.Domain.Entities
{
    public class Order : AggregateRoot
    {
        public decimal TotalPrice { get; private set; }
        public Custumer Custumer { get; private set; }
        public DeliveryAddress DeliveryAddress { get; private set; }
        public PaymentAddress PaymentAddress { get; private set; }
        public PaymentInfo PaymentInfo { get; private set; }
        public List<OrderItem> Items { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public OrderStatusEnum Status { get; private set; }

        public Order(Custumer custumer, DeliveryAddress deliveryAddress, PaymentAddress paymentAddress, PaymentInfo paymentInfo, List<OrderItem> items)
        {
            Id = Guid.NewGuid();
            TotalPrice = items.Sum(x => x.Quantity * x.Price);
            Custumer = custumer;
            DeliveryAddress = deliveryAddress;
            PaymentAddress = paymentAddress;
            PaymentInfo = paymentInfo;
            Items = items;
            CreatedAt = DateTime.UtcNow;
            AddEvent(new OrderCreated(Id, TotalPrice, PaymentInfo, Custumer.FullName, Custumer.Email));
        }

        public void SetAsCompleted()
        {
            Status = OrderStatusEnum.Completed;
        }
        public void SetRejected()
        {
            Status = OrderStatusEnum.Rejected;
        }
    }
}

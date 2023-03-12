using AwesomeShop.Domain.Entities;

namespace AwesomeShop.Application.Dtos.ViewModels
{
    public class OrderViewModel
    {

        public Guid Id { get; private set;}
        public decimal TotalPrice { get; private set;}
        public DateTime CreatedAt { get; private set;}
        public string Status { get; private set;}

        public OrderViewModel(decimal totalPrice, DateTime createdAt, string status)
        {
            Id = Guid.NewGuid();
            TotalPrice = totalPrice;
            CreatedAt = createdAt;
            Status = status;
        }

        public static OrderViewModel FromEntity(Order order)
        {
            return new OrderViewModel(order.TotalPrice, order.CreatedAt, order.Status.ToString());
        }
    }
}

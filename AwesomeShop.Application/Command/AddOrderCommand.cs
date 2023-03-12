using AwesomeShop.Application.Dtos.InputModels;
using AwesomeShop.Application.Dtos.ViewModels;
using AwesomeShop.Domain.Entities;
using AwesomeShop.Domain.ValueObjects;
using MediatR;

namespace AwesomeShop.Application.Command
{
    public class AddOrderCommand : IRequest<Guid>
    {
        public CustumerInputModel Custumer { get; set; }
        public List<OrderItemInputModel> Items { get; set; }
        public DeliveryAddressInputModel DeliveryAddress { get; set; }
        public PaymentAddressInputModel PaymentAddress { get; set; }  
        public PaymentInfoInputModel PaymentInfo { get; set; }

        public AddOrderCommand(CustumerInputModel custumer, List<OrderItemInputModel> items, DeliveryAddressInputModel deliveryAddress, PaymentAddressInputModel paymentAddress, PaymentInfoInputModel paymentInfo)
        {
            Custumer = custumer;
            Items = items;
            DeliveryAddress = deliveryAddress;
            PaymentAddress = paymentAddress;
            PaymentInfo = paymentInfo;
        }
        public Order ToEntity()
        {
            return new Order(
            new Custumer(Custumer.FullName, Custumer.Email), 
            new DeliveryAddress(DeliveryAddress.Street, DeliveryAddress.Number, DeliveryAddress.City, DeliveryAddress.State, DeliveryAddress.ZipCode),
            new PaymentAddress(PaymentAddress.Street, PaymentAddress.Number, PaymentAddress.City, PaymentAddress.State, PaymentAddress.ZipCode),
            new PaymentInfo(PaymentInfo.CardNumber, PaymentInfo.FullName, PaymentInfo.ExpirationDate, PaymentInfo.Cvv), 
            Items.Select(x => new OrderItem(x.ProductId, x.Quantity, x.Price)).ToList());
        }
    }
}

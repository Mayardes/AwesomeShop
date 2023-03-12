namespace AwesomeShop.Application.Dtos.InputModels
{
    public class OrderItemInputModel
    {
        public Guid ProductId { get; set;}
        public int Quantity { get; set;}
        public decimal Price { get; set;}

        public OrderItemInputModel(Guid productId, int quantity, decimal price)
        {
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }
    }
}

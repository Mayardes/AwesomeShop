using AwesomeShop.Application.Command;
using AwesomeShop.Application.Dtos.InputModels;
using Bogus;
using Swashbuckle.AspNetCore.Filters;

namespace AwesomeShop.API.Controllers.RequestOrderExamples
{
    public class AddOrderCommandRequestExample : IExamplesProvider<AddOrderCommand>
    {
        public AddOrderCommand GetExamples()
        {
            var faker = new Faker("pt_BR");

            return new AddOrderCommand
            (
                new CustumerInputModel(faker.Person.FullName, faker.Person.Email),
                new List<OrderItemInputModel>()
                {
                    new OrderItemInputModel(faker.Random.Guid(), faker.Random.Number(), faker.Commerce.Random.Decimal())
                },
                new DeliveryAddressInputModel(faker.Address.StreetName(), faker.Address.BuildingNumber(), faker.Address.City(), faker.Address.State(), faker.Address.ZipCode()),
                new PaymentAddressInputModel(faker.Address.StreetName(), faker.Address.BuildingNumber(), faker.Address.City(), faker.Address.State(), faker.Address.ZipCode()),
                new PaymentInfoInputModel(faker.Finance.CreditCardNumber(), faker.Person.FullName, DateTime.UtcNow.ToString(), faker.Finance.CreditCardCvv())
            );
        }
    }
}

namespace AwesomeShop.Application.Dtos.InputModels
{
    public class DeliveryAddressInputModel
    {

        public string Street { get; set;}
        public string Number { get; set;}
        public string City { get; set;}
        public string State { get; set;}
        public string ZipCode { get; set;}

        public DeliveryAddressInputModel(string street, string number, string city, string state, string zipCode)
        {
            Street = street;
            Number = number;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
    }

}

namespace AwesomeShop.Application.Dtos.InputModels
{
    public class PaymentInfoInputModel
    {

        public string CardNumber { get; set; }
        public string FullName { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvv { get; set; }

        public PaymentInfoInputModel(string cardNumber, string fullName, string expirationDate, string cvv)
        {
            CardNumber = cardNumber;
            FullName = fullName;
            ExpirationDate = expirationDate;
            Cvv = cvv;
        }
    }
}

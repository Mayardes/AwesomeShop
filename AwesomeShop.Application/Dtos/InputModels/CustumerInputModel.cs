namespace AwesomeShop.Application.Dtos.InputModels
{
    public class CustumerInputModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public CustumerInputModel(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }
    }

}

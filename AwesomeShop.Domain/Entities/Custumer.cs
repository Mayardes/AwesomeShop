namespace AwesomeShop.Domain.Entities
{
    public class Custumer : IEntityBase
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }

        public Custumer(Guid id, string fullName, string email)
        {
            Id = id;
            FullName = fullName;
            Email = email;
        }
    }
}

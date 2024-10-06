
namespace Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }

        public DateTime CreatedDate { get; set; }
        public ICollection<CustomerAddress> CustomerAddresses { get; set; } = [];

    }
}

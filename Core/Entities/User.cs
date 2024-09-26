
namespace Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool Enabled { get; set; }
        public bool IsDeleted { get; set; }
        
        public int? ProfileId { get; set; }
        public Profile Profile { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>(); // Inicialización de la colección

    }
}

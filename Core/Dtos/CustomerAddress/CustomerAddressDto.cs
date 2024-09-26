
namespace Core.Dtos.CustomerAddress
{
    public class CustomerAddressDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Street { get; set; }
        public string StreetDetail { get; set; }
        public string Number { get; set; }
        public string Zip { get; set; }
        public string Reference { get; set; }
        public bool IsPrincipal { get; set; }
        public bool Enabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }

    }
}

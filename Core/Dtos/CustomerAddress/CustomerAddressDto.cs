
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
    }
}

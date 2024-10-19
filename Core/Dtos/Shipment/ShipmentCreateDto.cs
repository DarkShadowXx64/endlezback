using Core.Dtos.CustomerAddress;

namespace Core.Dtos.Shipment;

public class ShipmentCreateDto
{
    public required Parcel Parcel { get; set; }
    public required CustomerAddressDto AddressFrom { get; set; }
    public required CustomerAddressDto AddressTo { get; set; }
    public required ShipmentContact Sender { get; set; }
    public required ShipmentContact Receiver { get; set; }
}

public class Parcel
{
    public int Length { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
}

public class ShipmentContact
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone1 { get; set; }
    public string? CompanyName { get; set; }
}
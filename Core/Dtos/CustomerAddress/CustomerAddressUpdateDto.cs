﻿namespace Core.Dtos.CustomerAddress
{
    public class CustomerAddressUpdateDto
    {
        public Guid Id { get; set; }
        public required string ZipCode { get; set; }
        public required string State { get; set; }
        public required string City { get; set; } // Municipio / Ciudad
        public required string Neighborhood { get; set; } // Colonia
        public required string Address1 { get; set; } // Calle y numero
        public required string Address2 { get; set; } // Datos adicionales
        public bool Residential { get; set; } // Si es residencial
        public Guid UserId { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Order
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; } // Propiedad para el ID del usuario
        public virtual User User { get; set; } // Propiedad de navegación

        public decimal Total { get; set; }

        public int OrderTypeId { get; set; }
        public virtual OrderType OrderType { get; set; }
        public Guid OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public bool Enabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }
        public DateTime? DeletedDate { get; set; } // Cambiado a Nullable para permitir valores nulos

        public List<OrderProduct> OrderProducts { get; set; }
    }
}
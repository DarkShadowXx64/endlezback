﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class OrderType
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public string? Description { get; set; }


    }
}

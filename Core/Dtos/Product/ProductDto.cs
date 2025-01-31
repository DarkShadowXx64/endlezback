﻿using Core.Dtos.Category;

namespace Core.Dtos.Product
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public List<string> Sizes { get; set; } = new List<string>(); // Representa las tallas disponibles
        public string ImagePath { get; set; } = string.Empty;
        public CategoryDto Category { get; set; }
    }
}

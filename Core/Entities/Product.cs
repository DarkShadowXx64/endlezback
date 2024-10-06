namespace Core.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ImagePath { get; set; }

        public Category Category { get; set; }

    }
}

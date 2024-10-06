namespace Core.Entities
{
    public class OrderProduct
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }

        // Navigation properties
        public Order Order { get; set; }
        public Product Product { get; set; }




    }
}

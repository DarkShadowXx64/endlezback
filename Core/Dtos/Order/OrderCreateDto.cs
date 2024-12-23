namespace Core.Dtos.Order
{
    public class OrderCreateDto
    {
        
        public Guid UserId { get; set; }
        public decimal Total { get; set; }

        public int OrderTypeId { get; set; }

        public Guid OrderStatusId { get; set; }
        public List<OrderProductCreateDto> Products { get; set; }

    }
}

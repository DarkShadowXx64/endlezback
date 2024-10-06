using System.ComponentModel.DataAnnotations; 



namespace Core.Entities
{
    public class Category
    {
        //bi
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

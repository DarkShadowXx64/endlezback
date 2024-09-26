using System.ComponentModel.DataAnnotations; 



namespace Core.Entities
{
    public class Category
    {
        //bi
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public bool Enabled { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        // Navigation property
        public ICollection<Product> Products { get; set; }
    }
}

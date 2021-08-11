namespace E_Store.Data.Models
{
    public class CategoryProduct
    {
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
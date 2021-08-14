namespace E_Store.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductEOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int ProductId { get; set; }
        
        public int EOrderId { get; set; }
        
        public int Quantity { get; set; }
        
        public virtual EOrder EOrder { get; set; }
        
        public virtual Product Product { get; set; }
    }
}
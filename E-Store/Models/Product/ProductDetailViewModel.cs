namespace E_Store.Models.Product
{
    using E_Store.Data.Models;
    
    public class ProductDetailViewModel
    {
        public Product Product { get; set; }
        
        public int Vat { get; set; }
        
        public bool IsVatPayer { get; set; }
    }
}
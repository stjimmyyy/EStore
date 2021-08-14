namespace E_Store.Data.Models
{
    using Classes;

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class EOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Token { get; set; }
        
        public DateTime Created { get; set; }
        
        [ForeignKey("Buyer")]
        public int? BuyerId { get; set; }
        
        [ForeignKey("Seller")]
        public int? SellerId { get; set; }

        public int? SellerAddressId { get; set; }
        
        public int? BuyerAddressId { get; set; }
        
        [ForeignKey("SellerPersonDetail")]
        public int? SellerPersonDetailId { get; set; }
        
        [ForeignKey("BuyerPersonDetail")]
        public int? BuyerPersonDetailId { get; set; }
        
        [ForeignKey("AccountantPersonDetail")]
        public int? AccountantDetailId { get; set; }
        
        public int? Number { get; set; }
        
        public DateTime? Issued { get; set; }
        
        public DateTime? DueDate { get; set; }
        
        public OrderState StateId { get; set; }
        
        public int? BuyerDeliveryAddressId { get; set; }
        
        [ForeignKey("DeliveryProduct")]
        public int? DeliveryProductId { get; set; }
        
        [ForeignKey("BankAccount")]
        public int? SellerBankAccountId { get; set; }
        
        public virtual Person Buyer { get; set; }
        
        public virtual Person Seller { get; set; }
        
        [ForeignKey("SellerAddressId")]
        public virtual Address SellerAddress { get; set; }
        
        [ForeignKey("BuyerAddressId")]
        public virtual Address BuyerAddress { get; set; }
        
        [ForeignKey("BuyerDeliveryAddressId")]
        public virtual Address BuyerDeliverAddress { get; set; }
        
        public virtual BankAccount BankAccount { get; set; }
        
        public virtual PersonDetail SellerPersonDetail { get; set; }
        
        public virtual PersonDetail BuyerPersonDetail { get; set; }
        
        public virtual PersonDetail AccountantPersonDetail { get; set; }
        
        public virtual Product DeliveryProduct { get; set; }

        public virtual ICollection<ProductEOrder> ProductEOrders { get; set; } = new List<ProductEOrder>();
    }
}
namespace E_Store.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    [JsonObject(IsReference = true)]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [ForeignKey("User")]
        public string UserId { get; set; }
        
        public int PersonDetailId { get; set; }
        
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        
        [ForeignKey("DeliveryAddress")]
        public int DeliveryAddressId { get; set; }
        
        public int? BankAccountId { get; set; }
        
        public virtual Address Address { get; set; }
        
        public virtual Address DeliveryAddress { get; set; }
        
        public virtual BankAccount BankAccount { get; set; }
        
        public virtual PersonDetail PersonDetail { get; set; }
        
        public virtual ApplicationUser User { get; set; }
    }
}
namespace E_Store.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BankAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int BankCode { get; set; }
        
        [StringLength(20)]
        public string AccountNumber { get; set; }
        
        [ForeignKey("BankCode")]
        public virtual Bank Bank { get; set; }
    }
}
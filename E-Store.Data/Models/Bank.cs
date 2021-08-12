namespace E_Store.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Bank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        
        [StringLength(255)]
        public string Name { get; set; }
        
        [StringLength(11)]
        public string Swift { get; set; }
    }
}
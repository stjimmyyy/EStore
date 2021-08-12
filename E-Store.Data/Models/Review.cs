namespace E_Store.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [StringLength(2048, MinimumLength = 2, ErrorMessage = "The minimal length is 2 characters, maximum length is 2048 characters")]
        public string Content { get; set; }
        
        public string UserId { get; set; }
        
        public int ProductId { get; set; }
        
        public int Rating { get; set; }
        
        public DateTime Sent { get; set; }

        public virtual Product Product { get; set; }
        
        public virtual ApplicationUser User { get; set; }
    }
}
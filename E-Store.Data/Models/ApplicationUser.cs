namespace E_Store.Data.Models
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;
    public class ApplicationUser : IdentityUser
    {
        public virtual Person Person { get; set; }
        
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
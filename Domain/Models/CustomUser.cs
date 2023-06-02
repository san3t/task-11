using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class CustomUser
    {
        public CustomUser()
        {
            Carts = new HashSet<Cart>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? UserEmail { get; set; }
        public string UserRole { get; set; } = null!;
        public string UserPassword { get; set; } = null!;

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}

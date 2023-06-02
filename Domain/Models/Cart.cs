using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Cart
    {
        public Cart()
        {
            Bookings = new HashSet<Booking>();
            CartItems = new HashSet<CartItem>();
        }

        public int CartId { get; set; }
        public int CustomerId { get; set; }

        public virtual CustomUser Customer { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}

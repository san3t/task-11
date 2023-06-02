using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class CartItem
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Qty { get; set; }
        public int? Price { get; set; }

        public virtual Cart Cart { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}

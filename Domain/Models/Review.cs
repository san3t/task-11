using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Review
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string? ReviewText { get; set; }
        public int ReviewRating { get; set; }

        public virtual CustomUser Customer { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}

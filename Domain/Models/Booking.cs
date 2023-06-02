using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int CartId { get; set; }
        public int? BookingPrice { get; set; }
        public string BookingStatus { get; set; } = null!;
        public string BookingDelivery { get; set; } = null!;
        public string BookingAddress { get; set; } = null!;

        public virtual Cart Cart { get; set; } = null!;
    }
}

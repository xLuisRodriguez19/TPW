using System;
using System.Collections.Generic;

namespace SuperShop.Models.Data
{
    public partial class Tracking
    {
        public long Id { get; set; }
        public long ShippingId { get; set; }
        public string Location { get; set; } = null!;
        public string Latitud { get; set; } = null!;
        public string Longitud { get; set; } = null!;
        public DateTime Fecha { get; set; }
    }
}

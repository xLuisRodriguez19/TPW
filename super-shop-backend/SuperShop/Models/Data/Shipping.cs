using System;
using System.Collections.Generic;

namespace SuperShop.Models.Data
{
    public enum Status
    {
        Preparando,
        EnCamino,
        EnSucursal,
        EnEntrega,
        Entregado
    }
    public partial class Shipping
    {
        public long Id { get; set; }
        public string IdUser { get; set; } = null!;
        public string NameO { get; set; } = null!;
        public string AddressO { get; set; } = null!;
        public string NameD { get; set; } = null!;
        public string AddressD { get; set; } = null!;
        public double PriceP { get; set; }
        public double PriceD { get; set; }
        public double Total { get; set; }
        public int Status { get; set; }
        public DateTime Fecha { get; set; }
    }
}

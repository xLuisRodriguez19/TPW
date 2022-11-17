using SuperShop.Models.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SuperShop.Business.Shipping.Services
{
    public class ShippingRequestDto
    {
        public string idUser { get; set; }
        public string nameO { get; set; }
        public string addressO { get; set; }
        public string nameD { get; set; }
        public string addressD { get; set; }
        public double priceP { get; set; }
        public double priceD { get; set; }
        public double total { get; set; }
    }
}

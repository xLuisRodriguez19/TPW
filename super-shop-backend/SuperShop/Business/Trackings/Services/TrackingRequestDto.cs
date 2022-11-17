using SuperShop.Models.Data;

namespace SuperShop.Business.Tracking.Services
{
    public class TrackingRequestDto
    {
        public long idShipping { get; set; }
        public string location { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public Status Status { get; set; }  
    }
}

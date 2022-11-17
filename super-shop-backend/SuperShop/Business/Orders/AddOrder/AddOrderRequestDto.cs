namespace SuperShop.Business.Orders.AddOrder
{
    public class AddOrderRequestDto
    {
        public long shippingId { get; set; }
        public string location { get; set; }
        public string latitud { get; set; }
        public string? longitud { get; set; }
        public int status { get; set; }
    }
}

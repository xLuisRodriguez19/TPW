
using SuperShop.Business.Shipping.Services;
using SuperShop.Business.Tracking.Services;
using SuperShop.Models.Data;

namespace SuperShop.Business.Orders.AddOrder
{
    public class AddOrderService
    {
        private readonly FakeDexContext _coreContex;
        private readonly ShippingService _shippingService;
        private readonly EmailService _emailService;

        public AddOrderService(FakeDexContext coreContex, ShippingService shippingService, EmailService emailService)
        {
            _coreContex = coreContex;
            _shippingService = shippingService;
            _emailService = emailService;
        }

        public async Task<long> AddOrder(AddOrderRequestDto addOrderRequest)
        {
            var shi = await _coreContex.Shipping.FindAsync(addOrderRequest.shippingId);
            if (shi == null)
            {
                Console.WriteLine($"Bill total:\t{addOrderRequest.shippingId}");
                Console.WriteLine($"Bill total:\t{addOrderRequest.location}");
                Console.WriteLine($"Bill total:\t{addOrderRequest.latitud}");
                Console.WriteLine($"Bill total:\t{addOrderRequest.longitud}");
                Console.WriteLine($"Bill total:\t{addOrderRequest.status}");
            }
            var order = new Models.Data.Tracking
            {
                ShippingId = addOrderRequest.shippingId,
                Location = addOrderRequest.location,
                Latitud = addOrderRequest.latitud,
                Longitud = addOrderRequest.longitud,
                Fecha = DateTime.Now
            };

            await _coreContex.Tracking.AddAsync(order);
            await _shippingService.updateStatus(shi.Id, addOrderRequest.status);
            await _coreContex.SaveChangesAsync();
            await _emailService.SendEmail(shi.IdUser, order.Location, addOrderRequest.status);
            return order.Id;
        }
    }
}

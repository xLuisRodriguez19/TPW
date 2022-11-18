using SuperShop.Models.Data;
using Microsoft.EntityFrameworkCore;
using SuperShop.Business.Tracking.Services;

namespace SuperShop.Business.Shipping.Services
{
    public class ShippingService
    {
        private readonly FakeDexContext _fakeDexContext;
        private readonly EmailService _emailService;

        public ShippingService(FakeDexContext fakeDexContext, EmailService emailService)
        {
            _fakeDexContext = fakeDexContext;
            _emailService = emailService;

        }

        public async Task<long> AddShipping(ShippingRequestDto shippingRequestDto)
        {
            var user = await _fakeDexContext.User.FindAsync(shippingRequestDto.idUser);
            var shipping = new Models.Data.Shipping
            {
                IdUser = user.Email,
                NameO = shippingRequestDto.nameO,
                AddressO = shippingRequestDto.addressO,
                NameD = shippingRequestDto.nameD,
                AddressD = shippingRequestDto.addressD,
                PriceD = shippingRequestDto.priceD,
                PriceP = shippingRequestDto.priceP,
                Total = shippingRequestDto.total,
                Fecha = DateTime.Now

            };
            await _fakeDexContext.Shipping.AddAsync(shipping);
            await _fakeDexContext.SaveChangesAsync();
            await _emailService.SendEmail(shipping.IdUser, "Espera de ser Recolectado", 0);
            return shipping.Id;
        }


        public async Task<List<Models.Data.Shipping>> GetShippings()
        {
            return await _fakeDexContext.Shipping.ToListAsync();
        }

        public async Task<Models.Data.Shipping> GetShippingById(long id)
        {
            return await _fakeDexContext.Shipping.FindAsync(id);
        }


        public async Task<long> updateStatus(long id, int status)
        {
           var shipping = await _fakeDexContext.Shipping.FindAsync(id);
            if (shipping != null)
            {
                shipping.Status = status;
                _fakeDexContext.SaveChanges();
            }
            return shipping.Id;
        }

        public async Task<List<Models.Data.Shipping>> GetShippingByUser(string id)
        {
            Console.WriteLine($"Bill total:\t{id}");
            return await _fakeDexContext.Shipping.Where(s => s.IdUser == id).OrderByDescending(t => t.Id).ToListAsync();
        }

        public async Task<List<Charts>> GetHistory()
        {
            return await _fakeDexContext.Shipping.Where(l => l.Fecha >= DateTime.UtcNow.AddDays(-10)).GroupBy(s  => new
            {
                s.Fecha.Date
            }).Select(s => new Charts{
                Fecha = s.Key.Date,
                shippings = s.Select(l => l.Id).Count()
            }).ToListAsync();
        }
    }
}

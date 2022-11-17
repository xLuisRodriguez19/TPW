using SuperShop.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace SuperShop.Business.Shipping.Services
{
    public class ShippingService
    {
        private readonly FakeDexContext _fakeDexContext;

        public ShippingService(FakeDexContext fakeDexContext)
        {
            _fakeDexContext = fakeDexContext;
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
    }
}

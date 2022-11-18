using SuperShop.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace SuperShop.Business.Tracking.Services
{
    public class TrackingService
    {
        private readonly FakeDexContext _fakeDexContext;
        private readonly EmailService _emailService;

        public TrackingService(FakeDexContext fakeDexContext, EmailService emailService)
        {
            _fakeDexContext = fakeDexContext;
            _emailService = emailService;   
        }

        public async Task<long> StartTracking(TrackingRequestDto trackingRequestDto)
        {
            Console.WriteLine(trackingRequestDto.location+"id");
            var shipping = await _fakeDexContext.Shipping.FindAsync(trackingRequestDto.idShipping);

            var tracking = new Models.Data.Tracking
            {
                ShippingId = shipping.Id,
                Location = trackingRequestDto.location,
                Latitud = trackingRequestDto.latitud,
                Longitud = trackingRequestDto.longitud,
                Fecha = DateTime.Now

            };
            await _fakeDexContext.Tracking.AddAsync(tracking);
            shipping.Status =((int)trackingRequestDto.Status);
            _fakeDexContext.Shipping.Update(shipping);
            await _fakeDexContext.SaveChangesAsync();
            //await _emailService.SendEmail(shipping.IdUser, tracking.Location, trackingRequestDto.Status);
            return tracking.Id;
        }
        public async Task<List<Models.Data.Tracking>> GetTrackingById(long id)
        {
            return await _fakeDexContext.Tracking.Where(t => t.ShippingId == id).OrderByDescending(t => t.Id).ToListAsync();
        }

        public async Task<long> aaTracking(long idShipping, string location, string latitud, string longitud, int status)
        {
            var shipping = await _fakeDexContext.Shipping.FindAsync(idShipping);

            var tracking = new Models.Data.Tracking
            {
                ShippingId = shipping.Id,
                Location = location,
                Latitud = latitud,
                Longitud = longitud,
                Fecha = DateTime.Now

            };
            await _fakeDexContext.Tracking.AddAsync(tracking);
            shipping.Status = ((int)status);
            _fakeDexContext.Shipping.Update(shipping);
            await _fakeDexContext.SaveChangesAsync();

            return tracking.Id;
        }
    }
}

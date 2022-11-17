using SuperShop.Business.Tracking.Services;
using SuperShop.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SuperShop.Controllers.Trackings
{
    public class TrackingController : ControllerBase
    {
        
        private readonly FakeDexContext _context;
        private readonly TrackingService _trackingService;

        public TrackingController(TrackingService trackingService)
        {
            _trackingService = trackingService;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> StartTracking([FromBody] TrackingRequestDto trackingRequestDto)
        {
            return Ok(await _trackingService.StartTracking(trackingRequestDto));
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> UpdateTracking([FromQuery] long id)
        {
            return Ok(await _trackingService.GetTrackingById(id));
        }

        [HttpPatch]
        [Route("api/[controller]/update")]
        public async Task<IActionResult> UpdateTracking([FromBody] TrackingRequestDto trackingRequestDto)
        {
            return Ok(await _trackingService.StartTracking(trackingRequestDto));
        }
    }
}
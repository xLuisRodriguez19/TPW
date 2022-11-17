using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperShop.Models.Data;
using SuperShop.Business.Login.Services;
using SuperShop.Business.Shipping.Services;
using Microsoft.AspNetCore.Authorization;

namespace SuperShop.Business.Shipping
{
    public class ShippingsController : ControllerBase
    {
        private readonly FakeDexContext _context;
        private readonly ShippingService _shippingService;

        public ShippingsController(ShippingService shippingService)
        {
            _shippingService = shippingService;
        }

        [HttpPost]
        [Authorize]
        [Route("api/[controller]")]
        public async Task<IActionResult> AddShipping([FromBody] ShippingRequestDto shippingRequestDto)
        {
            return Ok(await _shippingService.AddShipping(shippingRequestDto));
        }

        [HttpGet]
        [Authorize]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetShipping()
        {
            return Ok(await _shippingService.GetShippings());
        }

        [HttpGet]
        [Route("api/[controller]/id")]
        public async Task<IActionResult> GetShippingById(long id)
        {
            return Ok(await _shippingService.GetShippingById(id));
        }

        [HttpGet]
        [Route("api/[controller]/user/{user}")]
        public async Task<IActionResult> GetShippingByUser([FromRoute] string user)
        {
            Console.WriteLine($"Bill total:\t{user}");
            return Ok(await _shippingService.GetShippingByUser(user));
        }
    }
}

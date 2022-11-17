﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperShop.Business.Orders.AddOrder;
using SuperShop.Business.Orders.GetOrder;
namespace SuperShop.Business.Orders
{

    [Authorize]
    public class OrdersController: ControllerBase
    {

        private readonly ILogger<OrdersController> _logger;
        private readonly AddOrderService _addOrderService;
        private readonly GetOrderService _getOrderService;

        public OrdersController(ILogger<OrdersController> logger, AddOrderService addOrderService, GetOrderService getOrderService
            )
        {
            _logger = logger;
            _addOrderService = addOrderService;
            _getOrderService = getOrderService;
        }

        //    [HttpGet]
        //    [Route("api/[controller]/{userId:long}")]
        //    public async Task<IActionResult> GetOrders([FromRoute] long userId)
        //    {
        //        try
        //        {
        //            if (userId != 0)
        //            {
        //                return Ok(await _getOrderService.GetOrderByUser(userId));
        //            }
        //            else
        //            {
        //                return Ok(await _getOrderService.GetAll());
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            _logger.LogError(e, e.Message);
        //            return StatusCode(StatusCodes.Status500InternalServerError);
        //        }
        //    }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> AddOrder([FromBody] AddOrderRequestDto addOrderRequestDto)
        {
            try { 
                return Ok(await _addOrderService.AddOrder(addOrderRequestDto));
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

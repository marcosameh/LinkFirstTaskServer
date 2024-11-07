﻿using App.BL;
using App.BL.DTOs;
using App.BL.Models;
using App.DAL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<int>>> Create([FromBody] CreateOrderDto orderDto)
        {


            var response = await _orderService.CreateOrderAsync(orderDto);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        [HttpGet("{orderId}")]
        public async Task<ActionResult<ApiResponse<OrderDto>>> GetOrder(int orderId)
        {
            var response = await _orderService.GetOrder(orderId);
            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }

        [HttpPost("submit")]
        public async Task<ActionResult<ApiResponse<OrderDto>>> SubmitOrder([FromBody] SubmitOrderDto orderDto)
        {
            var response = await _orderService.SubmitOrderAsync(orderDto);
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}

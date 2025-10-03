using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundWaveMusic.Models;
using AutoMapper;
using SoundWaveMusic.Entities;
using BusinessLayer.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        // GET: api/order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrderAsync();
            return Ok(_mapper.Map<List<OrderModel>>(orders));
        }

        // GET: api/order
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderModel>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();
                
            return Ok(_mapper.Map<OrderModel>(order));
        }

        // POST: api/order
        [HttpPost]
        public async Task<ActionResult<OrderModel>> AddOrder([FromBody] OrderModel orderModel)
        {
            var order = _mapper.Map<Order>(orderModel);

            await _orderService.AddOrderAsync(order);

            var createdModel = _mapper.Map<OrderModel>(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = createdModel.OrderId }, createdModel);
        }

        //PUT: api/order/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderModel orderModel)
        {
            if (id != orderModel.OrderId)
                return BadRequest("Order ID does not match.");

            var order = _mapper.Map<Order>(orderModel);

            await _orderService.UpdateOrderAsync(order);
            return NoContent();
        }

        //DELETE: api/order/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}

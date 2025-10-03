using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoundWaveMusic.BusinessLayer.Interfaces;
using SoundWaveMusic.Domain.Entities;

namespace SoundWaveMusic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        // GEt: api/orderitem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetAllOrderItems()
        {
            var orderItems = await _orderItemService.GetAllOrderItemsAsync();
            if (orderItems == null)
            {
                return NotFound();
            }

            return Ok(orderItems);
        }

        // GET: api/orderitem/{id}
        public async Task<ActionResult<OrderItem>> GetOrderItemById(int id)
        {
            var orderItem = await _orderItemService.GetOrderItemByIdAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            return Ok(orderItem);
        }

        // POST: api/orderitem
        [HttpPost]
        public async Task<ActionResult<OrderItem>> AddOrderItem([FromBody] OrderItem orderItem)
        {
            await _orderItemService.AddAsync(orderItem);
            return CreatedAtAction(nameof(GetOrderItemById), new { id = orderItem.OrderItemId }, orderItem);
        }

        //DELETE: api/orderitem/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrderItem(int id)
        {
            await _orderItemService.DeleteAsync(id);
            return NoContent();
        }
    }
}

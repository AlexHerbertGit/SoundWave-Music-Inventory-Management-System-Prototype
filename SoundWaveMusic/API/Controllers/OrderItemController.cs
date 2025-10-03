using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using SoundWaveMusic.Entities;
using BusinessLayer.Interfaces;
using SoundWaveMusic.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IMapper _mapper;

        public OrderItemController(IOrderItemService orderItemService, IMapper mapper)
        {
            _orderItemService = orderItemService;
            _mapper = mapper;
        }

        // GEt: api/orderitem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItemModel>>> GetAllOrderItems()
        {
            var items = await _orderItemService.GetAllOrderItemsAsync();

            return Ok(_mapper.Map<List<OrderItemModel>>(items));
        }

        // GET: api/orderitem/{orderId}
        [HttpGet("{orderId}")]
        public async Task<ActionResult<IEnumerable<OrderItemModel>>> GetOrderItemsById(int orderId)
        {
            var items = await _orderItemService.GetOrderItemByIdAsync(orderId);
            if (items == null || !items.Any())
                return NotFound();

            return Ok(_mapper.Map<List<OrderItemModel>>(items));
        }

        // POST: api/orderitem
        [HttpPost]
        public async Task<ActionResult<OrderItemModel>> AddOrderItem([FromBody] OrderItemModel orderItemModel)
        {
            var item = _mapper.Map<OrderItem>(orderItemModel);
            await _orderItemService.AddAsync(item);

            var createdModel = _mapper.Map<OrderItemModel>(item);
            return CreatedAtAction(nameof(GetOrderItemsById), new { orderId = createdModel.OrderId }, createdModel);
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

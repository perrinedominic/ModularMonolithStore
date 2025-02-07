using Microsoft.AspNetCore.Mvc;
using ModularMonolithStore.Modules.Orders.DTOs;
using ModularMonolithStore.Modules.Orders.Models;
using ModularMonolithStore.Modules.Orders.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ModularMonolithStore.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public async Task<ActionResult<Order>> GetAllAsync()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            return Ok(order);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task Post([FromBody] OrderDto orderDto)
        {
            var order = new Order
            {
               
            };

            await _orderService.AddAsync(order);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async void Put(OrderDto orderDto)
        {
            var order = new Order
            {

            };

            await _orderService.UpdateAsync(order);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using backend.Model;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly DBWork _dbWork;

        public OrderController(DBWork db)
        {
            _dbWork = db;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            await _dbWork.AddOrderAsunc(order.Name, order.Email, order.TelNum);
            return CreatedAtAction(nameof(AddOrder), order);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using orderApi.RequestModel;
using orderApi.Services;
using System.Threading.Tasks;

namespace orderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : Controller
    {
        private readonly ItemService itemService;
        private readonly OrderService orderService;

        public MenuController(ItemService itemService, OrderService orderService)
        {
            this.itemService = itemService;
            this.orderService = orderService;
        }

        //User should be able to see the list of available items
        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            return Ok(await itemService.GetAllItems());
        }

        //User should be able to order them
        [HttpPost("order")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderInputModel orderInput)
        {
            return Ok(await orderService.PlaceAnOrder(orderInput.Items, orderInput.CustomerName));
        }

    }
}

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

        //user should get an notification after fixed amount of time that your order is ready
        //This EP should be called by an cronjob every 1 minut for example.
        [HttpPut("readyorder")]
        public async Task<IActionResult> GetOrdersReady()
        {
            return Ok(await orderService.GetOrdersReady());
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using orderApi.Models;
using orderApi.Services;
using System.Threading.Tasks;

namespace orderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {
        private readonly ItemService itemService;

        public ItemController(ItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            return Ok(await itemService.GetAllItems());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemDetails(string id)
        {
            return Ok(await itemService.GetItemById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] Item item)
        {
            if (item == null)
                return BadRequest();

            await itemService.InsertItem(item);

            return Created("Item created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem([FromBody] Item item, string id)
        {
            if (item == null)
                return BadRequest();

            item.Id = new ObjectId(id).ToString();

            await itemService.UpdateItem(item);

            return Created("Item created", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(string id)
        {
            await itemService.DeleteItem(id);

            return NoContent();
        }
    }
}

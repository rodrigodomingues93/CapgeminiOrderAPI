using CapgeminiOrderAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CapgeminiOrderAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrderController : ControllerBase
	{
		private static List<OrderModel> Orders = new List<OrderModel>();

		[HttpPost]
		public IActionResult Post([FromBody] OrderModel order)
		{
			if (order.Id == System.Guid.Empty)
				return BadRequest();

			Orders.Add(order);
			return Ok(order);
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok(Orders);
		}

		[HttpGet("{id}")]
		public IActionResult Get(Guid id)
		{
			return Ok(Orders.FirstOrDefault(w => w.Id == id));
		}

		[HttpPut]
		public IActionResult Put([FromBody] OrderModel order)
		{
			var orderUpdate= Orders.FirstOrDefault(w => w.Id == order.Id);
			if (orderUpdate == null)
				return NotFound();

			orderUpdate.Number= order.Number;
			orderUpdate.Client= order.Client;
			orderUpdate.Adress= order.Adress;
			orderUpdate.Product= order.Product;
			return Ok(order);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(Guid id)
		{
			var orderDelete= Orders.FirstOrDefault(w => w.Id ==id);
			Orders.Remove(orderDelete);
			return Ok(true);
		}
	}
}

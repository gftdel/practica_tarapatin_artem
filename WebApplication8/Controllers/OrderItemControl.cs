using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemControl : ControllerBase
    {
        public PracticaContext Context { get; }
        public OrderItemControl(PracticaContext context)
        {
            Context = context;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            List<OrderItem> order_item = Context.OrderItems.ToList();
            return Ok(order_item);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            OrderItem? order_item = Context.OrderItems.Where(x => x.Id == id).FirstOrDefault();
            if (order_item == null)
            {
                return BadRequest("Not Found");
            }
            return Ok();
        }
        [HttpPost]
        public ActionResult Add(OrderItem order_item)
        {
            Context.OrderItems.Add(order_item);
            Context.SaveChanges();
            return Ok(order_item);
        }
        [HttpPut]
        public ActionResult Update(OrderItem order_item)
        {
            Context.OrderItems.Add(order_item);
            Context.SaveChanges();
            return Ok(order_item);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            OrderItem? order_item = Context.OrderItems.Where(x => x.Id == id).FirstOrDefault();
            if (order_item == null)
            {
                return BadRequest("Not Found");
            }
            Context.OrderItems.Remove(order_item);
            Context.SaveChanges();
            return Ok(order_item);
        }
    }
}

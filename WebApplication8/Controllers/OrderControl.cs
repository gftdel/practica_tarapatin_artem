using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderControl : ControllerBase
    {
        public PracticaContext Context { get; }
        public OrderControl(PracticaContext context)
        {
            Context = context;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            List<Order> orders = Context.Orders.ToList();
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            Order? orders = Context.Orders.Where(x => x.Id == id).FirstOrDefault();
            if (orders == null)
            {
                return BadRequest("Not Found");
            }
            return Ok();
        }
        [HttpPost]
        public ActionResult Add(Order orders)
        {
            Context.Orders.Add(orders);
            Context.SaveChanges();
            return Ok(orders);
        }
        [HttpPut]
        public ActionResult Update(Order orders)
        {
            Context.Orders.Add(orders);
            Context.SaveChanges();
            return Ok(orders);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Order? orders = Context.Orders.Where(x => x.Id == id).FirstOrDefault();
            if (orders == null)
            {
                return BadRequest("Not Found");
            }
            Context.Orders.Remove(orders);
            Context.SaveChanges();
            return Ok(orders);
        }
    }
}

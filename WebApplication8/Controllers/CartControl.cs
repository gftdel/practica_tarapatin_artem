using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartControl : ControllerBase
    {
        public PracticaContext Context { get; }
        public CartControl(PracticaContext context)
        {
            Context = context;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            List<Cart> carts = Context.Carts.ToList();
            return Ok(carts);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            Cart? carts = Context.Carts.Where(x => x.Id == id).FirstOrDefault();
            if (carts == null)
            {
                return BadRequest("Not Found");
            }
            return Ok();
        }
        [HttpPost]
        public ActionResult Add(Cart carts)
        {
            Context.Carts.Add(carts);
            Context.SaveChanges();
            return Ok(carts);
        }
        [HttpPut]
        public ActionResult Update(Cart carts)
        {
            Context.Carts.Add(carts);
            Context.SaveChanges();
            return Ok(carts);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Cart? carts = Context.Carts.Where(x => x.Id == id).FirstOrDefault();
            if (carts == null)
            {
                return BadRequest("Not Found");
            }
            Context.Carts.Remove(carts);
            Context.SaveChanges();
            return Ok(carts);
        }
    }
}
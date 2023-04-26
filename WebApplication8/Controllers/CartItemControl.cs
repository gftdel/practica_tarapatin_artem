using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemControl : ControllerBase
    {
        public PracticaContext Context { get; }
        public CartItemControl(PracticaContext context)
        {
            Context = context;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            List<CartItem> cartsitm = Context.CartItems.ToList();
            return Ok(cartsitm);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            CartItem? cartsitm = Context.CartItems.Where(x => x.Id == id).FirstOrDefault();
            if (cartsitm == null)
            {
                return BadRequest("Not Found");
            }
            return Ok();
        }
        [HttpPost]
        public ActionResult Add(CartItem cartsitm)
        {
            Context.CartItems.Add(cartsitm);
            Context.SaveChanges();
            return Ok(cartsitm);
        }
        [HttpPut]
        public ActionResult Update(CartItem cartsitm)
        {
            Context.CartItems.Add(cartsitm);
            Context.SaveChanges();
            return Ok(cartsitm);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            CartItem? cartsitm = Context.CartItems.Where(x => x.Id == id).FirstOrDefault();
            if (cartsitm == null)
            {
                return BadRequest("Not Found");
            }
            Context.CartItems.Remove(cartsitm);
            Context.SaveChanges();
            return Ok(cartsitm);
        }
    }
}

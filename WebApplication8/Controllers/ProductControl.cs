using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductControl : ControllerBase
    {
        public PracticaContext Context { get; }
        public ProductControl(PracticaContext context)
        {
            Context = context;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            List<Product> products = Context.Products.ToList();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            Product? products = Context.Products.Where(x => x.Id == id).FirstOrDefault();
            if (products == null)
            {
                return BadRequest("Not Found");
            }
            return Ok();
        }
        [HttpPost]
        public ActionResult Add(Product products)
        {
            Context.Products.Add(products);
            Context.SaveChanges();
            return Ok(products);
        }
        [HttpPut]
        public ActionResult Update(Product products)
        {
            Context.Products.Add(products);
            Context.SaveChanges();
            return Ok(products);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Product? products = Context.Products.Where(x => x.Id == id).FirstOrDefault();
            if (products == null)
            {
                return BadRequest("Not Found");
            }
            Context.Products.Remove(products);
            Context.SaveChanges();
            return Ok(products);
        }
    }
}

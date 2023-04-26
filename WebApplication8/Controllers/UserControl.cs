using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControl : ControllerBase
    {
        public PracticaContext Context { get; }
        public UserControl(PracticaContext context)
        {
            Context = context;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            List<User> users = Context.Users.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            User? user = Context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            return Ok();
        }
        [HttpPost]
        public ActionResult Add(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
            return Ok(user);
        }
        [HttpPut]
        public ActionResult Update(User user) 
        {
            Context.Users.Add(user);
            Context.SaveChanges();
            return Ok(user);
        }
        [HttpDelete]
        public ActionResult Delete(int id) 
        {
            User? user = Context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            Context.Users.Remove(user);
            Context.SaveChanges();
            return Ok(user);
        }
    }
}

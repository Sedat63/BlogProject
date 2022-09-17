using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpGet("getList")]
        public List<User> GetList()
        {
            BlogContext db = new BlogContext();
            var result = db.Users.ToList();
            return result;
        }

        [HttpPost("addUser")]
        public IActionResult Add(User user)
        {
            BlogContext db = new BlogContext();
            db.Users.Add(user);
            db.SaveChanges();
            return Ok("Kullanıcı Eklendi");
        }

        [HttpPost("updateUser")]
        public IActionResult Update(User user)
        {
            BlogContext db = new BlogContext();

            var result = db.Users.FirstOrDefault(x => x.Id == user.Id);
            if (result != null)
            {
                result.Username = user.Username;
                result.Password = user.Password;
                db.SaveChanges();
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleteUser")]
        public IActionResult Delete(int id)
        {
            BlogContext db = new BlogContext();

            var result = db.Users.FirstOrDefault(x => x.Id == id);

            if (result != null)
            {
                db.Remove(result);
                db.SaveChanges();
                return Ok(result);
            }

            return BadRequest();
        }
    }
}

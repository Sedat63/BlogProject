using Entities.Concrete;
using Entities.Dto.UserDtos;
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

        [HttpPost("login")]
        public IActionResult Authenticate(UserForLoginDto user)
        {
            BlogContext db = new BlogContext();

            var result = db.Users.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
            if (user == null)
                
                return BadRequest(new { message = "Kullanici veya şifre hatalı!" });
            
            return Ok(user);
        }
          
              
    }
}
//Tek User olacak o yüzden listeleme olmayacak
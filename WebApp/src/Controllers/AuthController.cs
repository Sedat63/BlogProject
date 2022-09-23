using Entities.Concrete;
using Entities.Dto.UserDtos;
using Entities.Jwt;
using Entities.ObjectDesign;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebApp.Controllers
{
    public class AuthController : ApiBaseController
    {
        private JwtHelper _jwtHelper;   

        public AuthController(JwtHelper jwtHelper)
        {
            _jwtHelper = jwtHelper;
        }

        [HttpPost("login"), AllowAnonymous]
        public ServiceResponse Login(UserForLoginDto _user)
        {
            BlogContext db = new BlogContext();

            var user = db.Users
                .Include(x=>x.UserRoles).ThenInclude(x=>x.Role)
                .FirstOrDefault(x => x.Username == _user.Username && x.Password == _user.Password);

            if (user == null)
            {
                return new ServiceResponse("Şifre veya Kullanıcı Yanlış", false);
            }

            var accessToken = _jwtHelper.CreateToken(user, user.UserRoles.Select(x=>x.Role).ToList());

            return new ServiceResponse<AccessToken>(accessToken);
        }
    }
}
//Tek User olacak o yüzden listeleme olmayacak
using AutoMapper;
using Entities.Concrete;
using Entities.Dto.UserDtos;
using Entities.ObjectDesign;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace WebApp.Controllers
{

    public class UserController : ApiBaseController
    {
        private readonly IValidator<User> _validator;
        private readonly IMapper _mapper;
        BlogContext db = new BlogContext();

        public UserController(
            IValidator<User> validator,
            IMapper mapper)
        {
            _validator = validator;
            _mapper = mapper;
        }


        [HttpGet("get"), AllowAnonymous]
        public ServiceResponse<UserAdminRspDto> Get()
        {
            var user = db.Users
                .Select(x => new UserAdminRspDto
                {
                    Description = x.Description,
                    FullName = x.FullName,
                    Id = x.Id,
                    Password = x.Password,
                    Title = x.Title,
                    Username = x.Username,
                    ImagePath = x.ImagePath,
                }).FirstOrDefault();

            if (user == null)
                return new ServiceResponse<UserAdminRspDto>("Kullanıcı Silinmiş", false);

            return new ServiceResponse<UserAdminRspDto>(user);
        }

        [HttpPost("updateUser")]
        public ServiceResponse Update(ProfileAdminReqDto request)
        {
            var user = _mapper.Map<User>(request);

            var validationResult = _validator.Validate(user);

            if (!validationResult.IsValid)
            {
                return new ServiceResponse(string.Join(",", validationResult.Errors), false);
            }

            var dbUser = db.Users.FirstOrDefault();

            if (dbUser == null)
            {
                return new ServiceResponse("Bad Request --> Böyle bir kayıt bulunmuyor", false);
            }

            dbUser.Description = user.Description.Trim();
            dbUser.FullName = user.FullName.Trim();
            dbUser.Title = user.Title.Trim();
            dbUser.Username = user.Username.Trim();
            dbUser.Password = user.Password.Trim();

            db.SaveChanges();
            return new ServiceResponse("Kayıt Güncellendi");
        }



        [HttpPost("UpdateUserImage")]
        public ServiceResponse UpdateProfile([FromForm]ProfileImageAdminReqDto request)
        {
            #region add Image
            string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //{
            //    request.ImageFile.CopyTo(stream);
            //}
            #endregion

            #region its path save to db when it added the image
            var user = db.Users.FirstOrDefault();

            if (user == null)
                return new ServiceResponse("Kullanıcı Silinmiş", false);

            user.ImagePath = path;

            db.SaveChanges();
            #endregion

            return new ServiceResponse("Resim Başarıyla Güncellendi");
        }
    }
}

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

        public UserController(
            IValidator<User> validator,
            IMapper mapper)
        {
            _validator = validator;
            _mapper = mapper;
        }


        [HttpGet("get"), AllowAnonymous]
        public ServiceResponse<UserAdminResponseDto> Get()
        {
          using BlogContext db = new BlogContext();

            var user = db.Users
                .Select(x => new UserAdminResponseDto
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
                return new ServiceResponse<UserAdminResponseDto>("Kullanıcı Silinmiş", false);

            return new ServiceResponse<UserAdminResponseDto>(user);
        }

        [HttpPost("updateUser")]
        public ServiceResponse Update(ProfileAdminRequestDto request)
        {

            var user = _mapper.Map<User>(request);

            var validationResult = _validator.Validate(user);

            if (!validationResult.IsValid)
            {
                return new ServiceResponse(string.Join(",", validationResult.Errors), false);
            }
            using BlogContext db = new BlogContext();

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
        public ServiceResponse UpdateProfile([FromForm]ProfileImageAdminRequestDto request)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            using var fileStream = new FileStream(Path.Combine(path, request.ImageFile.FileName), FileMode.Create, FileAccess.ReadWrite, FileShare.Read);

            request.ImageFile.CopyTo(fileStream);

            using BlogContext db = new BlogContext();

            var user = db.Users.FirstOrDefault();

            if (user == null)
                return new ServiceResponse("Kullanıcı Silinmiş", false);

            user.ImagePath = $@"images\{request.ImageFile.FileName}"; ;

            db.SaveChanges();

            return new ServiceResponse("Resim Başarıyla Güncellendi");
        }
    }
}

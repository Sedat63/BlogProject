using AutoMapper;
using Entities.Concrete;
using Entities.Dto.SubscribeDtos;
using Entities.ObjectDesign;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Controllers
{
    public class SubscribeController : ApiBaseController
    {

        private readonly IMapper _mapper;
        private readonly IValidator<Subscribe> _validator;

        public SubscribeController(IMapper mapper,
            IValidator<Subscribe> validator)
        {
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet("getList"), AllowAnonymous]
        public ServiceResponse<List<SubscribeListResponseDto>> GetList()
        {
            BlogContext db = new BlogContext();

            var result = db.Subscribers
                .Where(x => x.IsDeleted == false)
                .Select(x => new SubscribeListResponseDto
            {
                Id = x.Id,
                Email = x.Email

            }).ToList();

            return new ServiceResponse<List<SubscribeListResponseDto>>(result);
        }

        [HttpPost("addSubscibe"), AllowAnonymous]
        public ServiceResponse AddSubscribe(SubscribeAddOrUpdateRequestDto request)
        {

            var subscribe = _mapper.Map<Subscribe>(request);

            var validationResult = _validator.Validate(subscribe);

            if(!validationResult.IsValid)
            {
                return new ServiceResponse(string.Join(",", validationResult.Errors), false);
            }

            BlogContext db = new BlogContext();

            string email = request.Email.Trim();

            var result = db.Subscribers.FirstOrDefault(x => x.Email == email);

            if (result == null)
            {
                db.Subscribers.Add(subscribe);
                db.SaveChanges();

                return new ServiceResponse("Abone Olundu");
            }
            else
            {
                return new ServiceResponse("Daha önceden abone olunmuştur", false);
            }
        }


        [HttpPost("updateSubscribe")]
        public ServiceResponse Update(SubscribeAddOrUpdateRequestDto request)
        {
            var subscribe = _mapper.Map<Subscribe>(request);

            var validationResult = _validator.Validate(subscribe);

            if (!validationResult.IsValid)
            {
                return new ServiceResponse(string.Join(",", validationResult.Errors), false);
            }
                 BlogContext db = new BlogContext();
            var result = db.Subscribers.FirstOrDefault(x => x.Id == request.Id);

            if (result == null)
            {
                return new ServiceResponse("Bad Request --> Böyle bir kayıt bulunmuyor", false);
            }
            subscribe.Email = subscribe.Email.Trim();
            db.SaveChanges();
            return new ServiceResponse("Üye Kaydı Güncellendi");
        }

        [HttpDelete("deleteSubscribe/{id}")]
        public ServiceResponse Delete(int id)
        {
            BlogContext db = new BlogContext();
            var result = db.Subscribers.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                return new ServiceResponse("Bad Request --> Böyle bir kayıt bulunmuyor");
            }
            result.IsDeleted = true;
            db.SaveChanges();
            return new ServiceResponse("Kayıt Silindi");
        }
    }
}

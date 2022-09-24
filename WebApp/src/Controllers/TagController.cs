using AutoMapper;
using Entities.Concrete;
using Entities.Dto.TagDtos;
using Entities.ObjectDesign;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Controllers
{

    public class TagController : ApiBaseController
    {
        private readonly IValidator<Tag> _validator;
        private readonly IMapper _mapper;

        public TagController(
            IValidator<Tag> validator,
            IMapper mapper)
        {
            _validator = validator;
            _mapper = mapper;
        }



        [HttpGet("getList"),AllowAnonymous]
        public ServiceResponse<IList<TagListResponseDto>> GetList()
        {
           using BlogContext db = new BlogContext();

            var list = db.Tags
                .Where(x => !x.IsDeleted)
                .Select(x => new TagListResponseDto
                {
                    Id = x.Id,
                    TagName = x.TagName,

                }).ToList();


            return new ServiceResponse<IList<TagListResponseDto>>(list);
        }

        [HttpPost("addTag")]
        public ServiceResponse Add(TagAddOrUpdateRequestDto request)
        {
            var tag = _mapper.Map<Tag>(request);

            var validationResult = _validator.Validate(tag);

            if (!validationResult.IsValid)
            {
                return new ServiceResponse(string.Join(",", validationResult.Errors),false);
            }
            using BlogContext db = new BlogContext();

            // Service
            tag.TagName = tag.TagName.Trim();
            //DB
            db.Tags.Add(tag);
            db.SaveChanges();

            return new ServiceResponse("Etiket Eklendi");
        }

        [HttpPost("updateTag")]
        public ServiceResponse Update(TagAddOrUpdateRequestDto request)
        {
            var tag = _mapper.Map<Tag>(request);

            var validationResult = _validator.Validate(tag);

            if (!validationResult.IsValid)
            {
                return new ServiceResponse(string.Join(",", validationResult.Errors), false);
            }

            using BlogContext db = new BlogContext();

            var result = db.Tags.FirstOrDefault(x => x.Id == request.Id);

            if (result == null)
            {
                return new ServiceResponse("Bad Request --> Böyle bir kayıt bulunmuyor",false);
            }
            tag.TagName = tag.TagName.Trim();
            db.SaveChanges();
            return new ServiceResponse("Kayıt Güncellendi");
        }

        [HttpDelete("deleteTag/{id}")]
        public ServiceResponse Delete(int id)
        {
            using BlogContext db = new BlogContext();

            var result = db.Tags.FirstOrDefault(x => x.Id == id);

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

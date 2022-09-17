using AutoMapper;
using Entities.Concrete;
using Entities.Dto.TagDtos;
using Entities.Enums;
using Entities.ObjectDesign;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        private readonly IValidator<Tag> _validator;
        private readonly IMapper _mapper;
        BlogContext db = new BlogContext();

        public TagController(
            IValidator<Tag> validator,
            IMapper mapper)
        {
            _validator = validator;
            _mapper = mapper;
        }



        [HttpGet("getList")]
        public ServiceResponse<IList<TagListResponseDto>> GetList()
        {
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

using AutoMapper;
using Entities.Concrete;
using Entities.Dto.CategoryDtos;
using Entities.ObjectDesign;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Controllers
{
    public class CategoryController : ApiBaseController
    {
        private readonly IValidator<Category> _validator;
        private readonly IMapper _mapper;

        public CategoryController(
            IValidator<Category> validator,
            IMapper mapper)
        {
            _validator = validator;
            _mapper = mapper;
        }

        [HttpGet("getList"), AllowAnonymous]
        public ServiceResponse<List<CategoryListResponseDto>> GetList()
        {
          using BlogContext db = new BlogContext();

            var result = db.Categories
                .Include(x => x.ArticleCategories)
                .ThenInclude(x => x.Article)
                .Select(x => new CategoryListResponseDto
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
                Description=x.Description,
                ArticleCount = x.ArticleCategories.Count()
            }).ToList();

            return new ServiceResponse<List<CategoryListResponseDto>>(result);

        }

        [HttpPost("addCategory"),AllowAnonymous]
        public ServiceResponse Add(CategoryAddOrUpdateRequestDto request)
        {
            using BlogContext db = new BlogContext();

            var category = _mapper.Map<Category>(request);

            var validationResult = _validator.Validate(category);

            if (!validationResult.IsValid)
            {
                return new ServiceResponse(string.Join(",", validationResult.Errors), false);
            }
            // Service
            category.CategoryName = category.CategoryName.Trim();
            category.Description = category.Description.Trim();

            //DB
            db.Categories.Add(category);
            db.SaveChanges();

            return new ServiceResponse("Kategori Eklendi");

        }

        [HttpPost("updateCategory")]
        public ServiceResponse Update(CategoryAddOrUpdateRequestDto request)
        {
            var category = _mapper.Map<Category>(request);

            var validationResult = _validator.Validate(category);

            if (!validationResult.IsValid)
            {
                return new ServiceResponse(string.Join(",", validationResult.Errors), false);
            }

            using BlogContext db = new BlogContext();

            var result = db.Categories.FirstOrDefault(x => x.Id == request.Id);

            if (result == null)
            {
                return new ServiceResponse("Bad Request --> Böyle bir kayıt bulunmuyor", false);
            }
            // Service
            result.CategoryName = category.CategoryName.Trim();
            result.Description = category.Description.Trim();

            db.SaveChanges();
            return new ServiceResponse("Kayıt Güncellendi");
        }

        [HttpDelete("deleteCategory/{id}")]
        public ServiceResponse Delete(int id)
        {
            using BlogContext db = new BlogContext();

            var result = db.Categories.FirstOrDefault(x => x.Id == id);

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

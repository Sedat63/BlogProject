using AutoMapper;
using Entities.Concrete;
using Entities.Dto.ArticleDtos;
using Entities.Dto.CategoryDtos;
using Entities.Dto.TagDtos;
using Entities.ObjectDesign;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class ArticleController : ApiBaseController
    {
        private readonly IValidator<Article> _validator;
        private readonly IMapper _mapper;

        public ArticleController(
            IValidator<Article> validator,
            IMapper mapper)
        {
            _validator = validator;
            _mapper = mapper;
        }

        [HttpPost("getList")]
        public async Task<ServiceResponse<PaginatedList<ArticleListResponseDto>>> GetListForAdmin (ArticleAdminRequestFilterDto filter)
        {
            using BlogContext db = new BlogContext();

            var query = db.Articles
                .Include(x => x.ArticleCategories).ThenInclude(x => x.Category)
                .Include(x => x.ArticleTags).ThenInclude(x => x.Tag)
                .Where(x => !x.IsDeleted
                && string.IsNullOrWhiteSpace(filter.ArticleTitle) || x.Title.Contains(filter.ArticleTitle)
                && filter.CategoryId == null || x.ArticleCategories.Any(x => x.Category.Id == filter.CategoryId)
                && filter.TagId == null || x.ArticleTags.Any(x => x.Tag.Id == filter.TagId)
                && filter.PublishDate == null || x.PublishDate >= filter.PublishDate).AsQueryable();

            var dto = query.Select(x => new ArticleListResponseDto
            {
                Id = x.Id,
                Title = x.Title,
                ContentText = x.ContentText,
                PublishDate = x.PublishDate,
                ViewNumber = x.ViewNumber,
                IsBanner = x.IsBanner,
                HeaderImagePath =x.HeaderImagePath,
                LikeNumber = x.LikeNumber,
                Categories = x.ArticleCategories
                      .Select(y => new CategoryAdminResponseForArticleList { Id = y.Category.Id, CategoryName = y.Category.CategoryName }),
                Tags = x.ArticleTags.Select(y => new TagListResponseDto { Id = y.Tag.Id, TagName = y.Tag.TagName }),
            });

            if (filter.IsOrderBy)
            {
                query = query.OrderByDescending(a => a.GetType().GetProperty(filter.ColumnNameForOrder).GetValue(a, null));
            }

            var result = await PaginatedList<ArticleListResponseDto>.CreateAsync(dto.AsNoTracking(), filter.PageNumber, filter.PageSize).ConfigureAwait(false);

            return new ServiceResponse<PaginatedList<ArticleListResponseDto>>(result);
               

        }

        [HttpGet("getListForWeb"),AllowAnonymous]
        public async Task<ServiceResponse<PaginatedList<ArticleListResponseDto>>> GetListForWeb([FromQuery]ArticleWebRequestFilterDto filter)
        {
            using BlogContext db = new BlogContext();

            var query = db.Articles
                .Include(x => x.ArticleCategories).ThenInclude(x => x.Category)
                .Include(x => x.ArticleTags).ThenInclude(x => x.Tag)
                .Where(x => !x.IsDeleted
                && string.IsNullOrWhiteSpace(filter.Search) 
                || x.Title.Contains(filter.Search) 
                || x.ContentText.Contains(filter.Search)
                || x.ArticleCategories.Any(y=>y.Category.CategoryName.Contains(filter.Search))
                || x.ArticleTags.Any(y => y.Tag.TagName.Contains(filter.Search))
                || x.PublishDate.ToShortDateString().Contains(filter.Search)    
                && filter.CategoryId == null || x.ArticleCategories.Any(x => x.Category.Id == filter.CategoryId)
                && filter.TagId == null || x.ArticleTags.Any(x => x.Tag.Id == filter.TagId))
                .OrderByDescending(x => x.IsBanner).ThenByDescending(x=> x.PublishDate)
                .AsQueryable();

            var dto = query.Select(x => new ArticleListResponseDto
            {
                Id = x.Id,
                Title = x.Title,
                ContentText = x.ContentText,
                PublishDate = x.PublishDate,
                ViewNumber = x.ViewNumber,
                IsBanner = x.IsBanner,
                HeaderImagePath = x.HeaderImagePath,
                LikeNumber = x.LikeNumber,
                Categories = x.ArticleCategories
                      .Select(y => new CategoryAdminResponseForArticleList { Id = y.Category.Id, CategoryName = y.Category.CategoryName }),
                Tags = x.ArticleTags.Select(y => new TagListResponseDto { Id = y.Tag.Id, TagName = y.Tag.TagName }),
            });

            var result = await PaginatedList<ArticleListResponseDto>.CreateAsync(dto.AsNoTracking(), filter.PageNumber, filter.PageSize).ConfigureAwait(false);

            return new ServiceResponse<PaginatedList<ArticleListResponseDto>>(result);
        }

        [HttpPost("addArticle")]
        public ServiceResponse AddArticle([FromForm] ArticleAddRequestDto request)
        {
            var article = _mapper.Map<Article>(request);

            var validationResult = _validator.Validate(article);

            if (!validationResult.IsValid)
            {
                return new ServiceResponse(string.Join(",", validationResult.Errors), false);
            }
            using BlogContext db = new BlogContext();

            #region Add Banner Image 
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            using var fileStream = new FileStream(Path.Combine(path, request.BannerImage.FileName), FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
            
                request.BannerImage.CopyTo(fileStream);
                article.HeaderImagePath = $@"images\{request.BannerImage.FileName}";
            
            #endregion

            article.Title = article.Title.Trim();
            //DB
            db.Articles.Add(article);

            db.SaveChanges();

            return new ServiceResponse("Makale Eklendi");
        }

        [HttpPost("updateArticle")]
        public IActionResult Update(ArticleUpdateRequestDto request)
        {
            BlogContext db = new BlogContext();

            var result = db.Articles.FirstOrDefault(x => x.Id == request.Id);
            if (result != null)
            {
                result.Title = request.Title;
                result.ContentText = request.ContentText;
                result.PublishDate = request.PublishDate;
                result.ViewNumber = request.ViewNumber;
                result.LikeNumber = request.LikeNumber;
                db.SaveChanges();
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleteArticle/{id}")]
        public ServiceResponse Delete(int id)
        {
            using BlogContext db = new BlogContext();

            var result = db.Articles.FirstOrDefault(x => x.Id == id);

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

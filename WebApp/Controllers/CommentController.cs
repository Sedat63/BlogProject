using Entities.Concrete;
using Entities.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : Controller
    {
        [HttpGet("getList")]
        public List<CommentListResponseDto> GetList()
        {
            BlogContext db = new BlogContext();

            var result = db.Comments.Select(x => new CommentListResponseDto
            {
                Id = x.Id,
                Text = x.Text,
                Email = x.Email,
                UploadDate = x.UploadDate,
                FullName = x.FullName,
                LikeNumber = x.LikeNumber

            }).ToList();

            return result;
        }

        [HttpPost("AddComment")]
        public IActionResult Add(CommentAddOrUpdateRequestDto request)
        {
            BlogContext db = new BlogContext();

            var comment = new Comment()
            {
                Id = request.Id,
                Text = request.Text,
                Email = request.Email,
                UploadDate = request.UploadDate,
                FullName = request.FullName,
                LikeNumber = request.LikeNumber
            };

            db.Comments.Add(comment);
            db.SaveChanges();
            return Ok("Yorum Eklendi");
        }

        [HttpPost("updateComment")]
        public IActionResult Update(CommentAddOrUpdateRequestDto request)
        {
            BlogContext db = new BlogContext();

            var result = db.Comments.FirstOrDefault(x => x.Id == request.Id);
            if (result != null)
            {
                result.Text = request.Text;
                result.Email = request.Email;
                result.UploadDate = request.UploadDate;
                result.FullName = request.FullName;
                result.LikeNumber = request.LikeNumber;

                db.SaveChanges();
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleteComment")]
        public IActionResult Delete(int id)
        {
            BlogContext db = new BlogContext();

            var result = db.Comments.FirstOrDefault(x => x.Id == id);

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

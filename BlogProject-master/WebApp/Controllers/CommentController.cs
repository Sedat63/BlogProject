using Entities.Concrete;
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
        public List<Comment> GetList()
        {
            BlogContext db = new BlogContext();
            var result = db.Comments.ToList();
            return result;
        }

        [HttpPost("AddComment")]
        public IActionResult Add(Comment comment)
        {
            BlogContext db = new BlogContext();
            db.Comments.Add(comment);
            db.SaveChanges();
            return Ok("Yorum Eklendi");
        }

        [HttpPost("updateComment")]
        public IActionResult Update(Comment comment)
        {
            BlogContext db = new BlogContext();

            var result = db.Comments.FirstOrDefault(x => x.Id == comment.Id);
            if (result != null)
            {
                result.Text = comment.Text;
                result.Email = comment.Email;
                result.UploadDate = comment.UploadDate;
                result.FullName = comment.FullName;
                result.LikeNumber = comment.LikeNumber;
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

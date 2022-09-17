using Entities.Concrete;
using Entities.Dto.SocialMediaDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        [HttpGet("getList")]
        public List<SocialMediaListResponseDto> GetList()
        {
            BlogContext db = new BlogContext();
            var result = db.SocialMedias.Select(x => new SocialMediaListResponseDto
            {
                Id = x.Id,
                Link = x.Link,
                Icon = x.Icon,
                Title = x.Title
               
            }).ToList();

            return result;
        }

        [HttpPost("addSocial")]
        public IActionResult AddSocial(SocialMediaAddOrUpdateRequestDto request)
        {
            BlogContext db = new BlogContext();

            var social = new SocialMedia()
            {
                Id = request.Id,
                Link = request.Link,
                Icon = request.Icon,
                Title = request.Title
               
            };
            db.SocialMedias.Add(social);
            db.SaveChanges();
            return Ok("Sosyal Medya Eklendi");
        }

        [HttpPost("updateSocial")]
        public IActionResult UpdateSocial(SocialMediaAddOrUpdateRequestDto request)
        {
            BlogContext db = new BlogContext();

            var result = db.SocialMedias.FirstOrDefault(x => x.Id == request.Id);
            if (result != null)
            {
                result.Link = request.Link;
                result.Icon = request.Icon;
                result.Title = request.Title;
               
                db.SaveChanges();
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleteSocial")]
        public IActionResult Delete(int id)
        {
            BlogContext db = new BlogContext();

            var result = db.SocialMedias.FirstOrDefault(x => x.Id == id);

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

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
    public class TicketController : Controller
    {
        [HttpGet("getList")]
        public List<Ticket> GetList()
        {
            BlogContext db = new BlogContext();
            var result = db.Tickets.ToList();
            return result;
        }

        [HttpPost("addTicket")]
        public IActionResult Add(Ticket ticket)
        {
            BlogContext db = new BlogContext();
            db.Tickets.Add(ticket);
            db.SaveChanges();
            return Ok("Etiket Eklendi");
        }

        [HttpPost("updateTicket")]
        public IActionResult Update(Ticket ticket)
        {
            BlogContext db = new BlogContext();

            var result = db.Tickets.FirstOrDefault(x => x.Id == ticket.Id);
            if (result != null)
            {
                result.TicketName = ticket.TicketName;
               
                db.SaveChanges();
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("deleteTicket")]
        public IActionResult Delete(int id)
        {
            BlogContext db = new BlogContext();

            var result = db.Tickets.FirstOrDefault(x => x.Id == id);

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

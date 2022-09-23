using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomePageController
    {

        [HttpGet("Index")]
        public string Index()
        {
            return "Sedat Öztürk";
        }
    }
}
//

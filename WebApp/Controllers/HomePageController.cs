using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

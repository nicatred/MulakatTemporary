using Microsoft.AspNetCore.Mvc;
using MulakatAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MulakatAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
       
        [HttpPost("Writer")]
        public async Task<IActionResult> Writer([FromForm]string txt)
        {

            using StreamWriter file = new("Mulakat.txt");
            await file.WriteLineAsync(txt);
            
            return Json("Yazildi");
        }

        [HttpGet("Reader")]
        public async Task<IActionResult> Reader()
        {
            using StreamReader file = new("Mulakat.txt");
           
             string txt = await file.ReadToEndAsync();
            return Json(txt);
        }

    }
}

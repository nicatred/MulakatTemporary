using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MulakatUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Test")]
        public async Task<JsonResult> Test(string text)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307//api/Home");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<string>("Writer", text);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return Json("Success");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return  Json("Unsuccess");
        }
    }
}

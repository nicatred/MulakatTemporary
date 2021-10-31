using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MulakatClient.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MulakatClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

            return Json("Unsuccess");
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

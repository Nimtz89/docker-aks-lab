using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using docker_aks_lab_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace docker_aks_lab_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
            var model = new ExcuseModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                //HTTP GET
                var responseTask = await client.GetAsync("Excuses/getRandomExcuse");
                var result = await responseTask.Content.ReadAsStringAsync();
                model.Excuse = result;
            }

            return View(model);
        }
    }
}

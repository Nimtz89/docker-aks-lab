using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using docker_aks_lab_api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace docker_aks_lab_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcusesController : Controller
    {
        [HttpGet("getRandomExcuse")]
        public string GetRandomExcuse()
        {
            var excusesObject = JsonConvert.DeserializeObject<ExcusesModel>(System.IO.File.ReadAllText("Data\\Excuses.json"));
            var random = new Random();
            var excuseIndex = random.Next(excusesObject.Excuses.Length);
            var excuse = excusesObject.Excuses[excuseIndex];

            return excuse;
        }
    }
}

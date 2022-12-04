using System.Collections.Generic;
using Internet_Services_PG.Models;
using Internet_Services_PG.Services;
using Microsoft.AspNetCore.Mvc;

namespace Internet_Services_PG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HumidityController:ControllerBase
    {
        private readonly HumidityService _humidityService;

        public HumidityController(HumidityService humidityService)
        {
            _humidityService = humidityService;
        }

        [HttpGet]
        public ActionResult<List<Humidity>> Get()
        {
            return _humidityService.Get();
        }

        [HttpPost]
        public ActionResult<Humidity> Create(Humidity humidity)
        {
            _humidityService.Create(humidity);

            return CreatedAtRoute("GetBook", new { id = humidity.Id.ToString() }, humidity);
        }
    }
}
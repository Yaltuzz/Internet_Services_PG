using System.Collections.Generic;
using Internet_Services_PG.Models;
using Internet_Services_PG.Services;
using Microsoft.AspNetCore.Mvc;

namespace Internet_Services_PG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController:ControllerBase
    {
        private readonly TemperatureService _temperatureService;

        public TemperatureController(TemperatureService temperatureService)
        {
            _temperatureService = temperatureService;
        }

        [HttpGet]
        public ActionResult<List<Temperature>> Get()
        {
            return _temperatureService.Get();
        }

        [HttpPost]
        public ActionResult<Temperature> Create(Temperature temperature)
        {
            _temperatureService.Create(temperature);

            return CreatedAtRoute("GetTemperature", new { id = temperature.Id.ToString() }, temperature);
        }
    }
}
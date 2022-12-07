using System;
using System.Collections.Generic;
using Internet_Services_PG.Models;
using Internet_Services_PG.Services;
using Microsoft.AspNetCore.Mvc;

namespace Internet_Services_PG.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class PressureController: ControllerBase
    {
        private readonly PressureService _pressureService;

        public PressureController(PressureService pressureService)
        {
            _pressureService = pressureService;
        }

        [HttpGet]
        public ActionResult<List<Pressure>> Get()
        {
            return _pressureService.Get();
        }

        [HttpPost]
        public ActionResult<Pressure> Create(Pressure pressure)
        {
            _pressureService.Create(pressure);

            return CreatedAtRoute("GetPressure", new { id = pressure.Id.ToString() }, pressure);
        }
    }
}
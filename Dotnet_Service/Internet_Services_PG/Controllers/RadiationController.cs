using System.Collections.Generic;
using Internet_Services_PG.Models;
using Internet_Services_PG.Services;
using Microsoft.AspNetCore.Mvc;

namespace Internet_Services_PG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RadiationController:ControllerBase
    {
        private readonly RadiationService _radiationService;

        public RadiationController(RadiationService radiationService)
        {
            _radiationService = radiationService;
        }

        [HttpGet]
        public ActionResult<List<Radiation>> Get()
        {
            return _radiationService.Get();
        }

        [HttpPost]
        public ActionResult<Radiation> Create(Radiation radiation)
        {
            _radiationService.Create(radiation);

            return CreatedAtRoute("GetRadiation", new { id = radiation.Id.ToString() }, radiation);
        }
    }
}
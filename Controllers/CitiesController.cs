using System.Collections.Generic;
using System.Linq;
using DemoApplication1.Entities;
using DemoApplication1.Models;
using DemoApplication1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoApplication1.Controllers
{
     [Route("api/Cities")]
     public class CitiesController : Controller
     {
          private readonly ILogger<CitiesController> _logger;
          private readonly ICityInfoRepository _cityInfoRepository;
          public CitiesController(ILogger<CitiesController> logger,
          ICityInfoRepository cityInfoRepository)
          {
               _logger = logger;
               _cityInfoRepository = cityInfoRepository;
          }

          [HttpGet]
          public IActionResult GetCities()
          {
               // return new JsonResult(CitiesDataStore.Current.Citites);
               var cityEntities = _cityInfoRepository.GetCities();
               var results = new List<CityWithOutPointsOfInterest>();
               foreach (var cityEntitie in cityEntities)
               {
                    results.Add(new CityWithOutPointsOfInterest
                    {
                         Id = cityEntitie.Id,
                         Name = cityEntitie.Name,
                         Description = cityEntitie.Description
                    }
                    );
               }
               return Ok(results);

          }
          [HttpGet("{Id}")]
          public JsonResult GetCity(int Id)
          {
               return new JsonResult(
                   CitiesDataStore.Current.Citites.FirstOrDefault(pc => pc.Id == Id)
               );
          }
     }
}
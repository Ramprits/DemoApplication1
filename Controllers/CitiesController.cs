using System.Collections.Generic;
using AutoMapper;
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
               // var results = new List<CityWithOutPointsOfInterest>();
               // foreach (var cityEntitie in cityEntities)
               // {
               //      results.Add(new CityWithOutPointsOfInterest
               //      {
               //           Id = cityEntitie.Id,
               //           Name = cityEntitie.Name,
               //           Description = cityEntitie.Description
               //      }
               //      );
               // }
               var results = Mapper.Map<IEnumerable<CityWithOutPointsOfInterest>>(cityEntities);
               return Ok(results);

          }
          [HttpGet("{Id}")]
          public IActionResult GetCity(int Id, bool IncludePointsOfInterest = false)
          {
               //    return new JsonResult(
               //        CitiesDataStore.Current.Citites.FirstOrDefault(pc => pc.Id == Id)
               //    );

               var city = _cityInfoRepository.GetCity(Id, IncludePointsOfInterest);
               if (city == null)
               {
                    return NotFound();
               }

               if (IncludePointsOfInterest)
               {
                    // var cityResult = new CityDto()
                    // {
                    //      Id = city.Id,
                    //      Name = city.Name,
                    //      Description = city.Description
                    // };
                    // foreach (var poi in city.PointsOfInterests)
                    // {
                    //      cityResult.PointsOfInterest.Add(new PointsOfInterestDto()
                    //      {
                    //           Id = poi.Id,
                    //           Name = poi.Name,
                    //           Description = poi.Description
                    //      });
                    // }
                    var cityresult = Mapper.Map<CityDto>(city);
                    return Ok(cityresult);
               }

               var cityWithOutPointsOfInterest = Mapper.Map<CityWithOutPointsOfInterest>(city);
               // var CWpointsOfInterest = new CityWithOutPointsOfInterest()
               // {
               //      Id = city.Id,
               //      Name = city.Name,
               //      Description = city.Description
               // };
               return Ok(cityWithOutPointsOfInterest);
          }
     }
}
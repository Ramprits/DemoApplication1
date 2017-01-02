using System.Collections.Generic;
using System.Linq;
using DemoApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoApplication1.Controllers
{
     [Route("api/Cities")]
     public class CitiesController : Controller
     {
          private readonly ILogger<CitiesController> _logger;
          public CitiesController(ILogger<CitiesController> logger)
          {
               _logger = logger;
          }
          //[HttpGet]
          //   public IActionResult GetCities()
          //   {
          //        return new JsonResult(new List<object>(){
          //         new{id =101,Name="New Yark City"},
          //         new{id =102,Name="India"},
          //     });

          //   }
          [HttpGet]
          public IActionResult GetCities()
          {
               return new JsonResult(CitiesDataStore.Current.Citites);
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
using System.Linq;
using DemoApplication1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication1.Controllers
{
     [Route("api/Cities")]
     public class PointsOfInterestController : Controller
     {
          public PointsOfInterestController()
          {
          }
          [HttpGet("{cityId}/PointsOfInterest")]
          public IActionResult GetPointsOfInterest(int cityId)
          {
               var city = CitiesDataStore.Current.Citites.FirstOrDefault(pp => pp.Id == cityId);
               if (city == null)
               {
                    return BadRequest();
               }

               return Ok(city.PointsOfInterest);
          }

          [HttpGet("{cityId}/PointsOfInterest/{id}", Name = "GetPointOfInterest")]
          public IActionResult GetPointsOfInterest(int cityId, int Id)
          {
               var city = CitiesDataStore.Current.Citites.FirstOrDefault(pp => pp.Id == cityId);
               if (city == null)
               {
                    return BadRequest();
               }
               var pointsOfInterest = city.PointsOfInterest.FirstOrDefault(pp => pp.Id == Id);
               if (pointsOfInterest == null)
               {
                    return BadRequest();
               }
               return Ok(pointsOfInterest);
          }
          [HttpPost("{cityId}/PointsOfInterest")]
          public IActionResult Create(int cityId, [FromBody] PointsOfInterestCreationDto pointsOfInterest)
          {
               if (pointsOfInterest == null)
               {
                    return BadRequest();
               }
               var city = CitiesDataStore.Current.Citites.FirstOrDefault(pp => pp.Id == cityId);
               if (city == null)
               {
                    return BadRequest();
               }
               if (pointsOfInterest.Description == pointsOfInterest.Name)
               {
                    ModelState.AddModelError("Description", "The provided Description should be diffrent from Name ");
               }
               var maxPointsOfInterest
               = CitiesDataStore.Current.Citites.SelectMany(pp => pp.PointsOfInterest).Max(pp => pp.Id);
               var finalPointsOfInterest = new PointsOfInterestDto()
               {
                    Id = ++maxPointsOfInterest,
                    Name = pointsOfInterest.Name,
                    Description = pointsOfInterest.Description
               };
               city.PointsOfInterest.Add(finalPointsOfInterest);

               return CreatedAtRoute("GetPointOfInterest", new
               {
                    cityId = cityId,
                    id = finalPointsOfInterest.Id
               }, finalPointsOfInterest);
          }

          [HttpPut("{cityId}/PointsOfInterest/{Id}")]
          public IActionResult PointsOfInterestForUpdate(int cityId, int Id,
           [FromBody] PointsOfInterestForUpdateDto pointsOfInterest)
          {
               if (pointsOfInterest == null)
               {
                    return BadRequest();
               }
               var city = CitiesDataStore.Current.Citites.FirstOrDefault(pp => pp.Id == cityId);
               if (city == null)
               {
                    return BadRequest();
               }
               if (pointsOfInterest.Description == pointsOfInterest.Name)
               {
                    ModelState.AddModelError("Description", "The provided Description should be diffrent from Name ");
               }
               var pointsOfInterestForUpdate = city.PointsOfInterest.FirstOrDefault(pp => pp.Id == Id);
               if (pointsOfInterestForUpdate == null)
               {
                    return BadRequest();
               }
               pointsOfInterestForUpdate.Name = pointsOfInterest.Name;
               pointsOfInterestForUpdate.Description = pointsOfInterest.Description;


               return NoContent();
          }
     }
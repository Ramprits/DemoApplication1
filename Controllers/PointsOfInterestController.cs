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
           [FromBody] PointsOfInterestForUpdateDto pointsOfInterestUpdate)
          {
               if (pointsOfInterestUpdate == null)
               {
                    return NotFound();
               }
               if (!ModelState.IsValid)
               {
                    return BadRequest();
               }
               var city = CitiesDataStore.Current.Citites.FirstOrDefault(pp => pp.Id == cityId);
               if (city == null)
               {
                    return NotFound();
               }
               if (pointsOfInterestUpdate.Description == pointsOfInterestUpdate.Name)
               {
                    ModelState.AddModelError("Description", "The provided Description should be diffrent from Name ");
               }
               var pointsOfInterestForUpdateStore =
                city.PointsOfInterest.FirstOrDefault(pp => pp.Id == Id);
               if (pointsOfInterestForUpdateStore == null)
               {
                    return NotFound();
               }
               pointsOfInterestForUpdateStore.Name = pointsOfInterestUpdate.Name;
               pointsOfInterestForUpdateStore.Description = pointsOfInterestUpdate.Description;
               return NoContent();
          }
          // Here We will right Patch 


          // [HttpPut("{cityId}/PointsOfInterest/{Id}")]
          // public IActionResult UpdatePointsOfInterest(int cityId, int Id,
          //  [FromBody] PointsOfInterestForUpdateDto UpdateDtp)
          // {
          //      if (UpdateDtp == null)
          //      {
          //           return BadRequest();
          //      }
          //      var city = CitiesDataStore.Current.Citites.FirstOrDefault(c => c.Id == cityId);
          //      if (city == null)
          //      {
          //           return BadRequest();
          //      }
          //      var pointsOfInterestToUpdate = city.PointsOfInterest.FirstOrDefault(c => c.Id == Id);
          //      if (pointsOfInterestToUpdate == null)
          //      {
          //           return BadRequest();
          //      }
          //      if (!ModelState.IsValid)
          //      {
          //           return BadRequest();
          //      }
          //      if (UpdateDtp.Description == UpdateDtp.Name)
          //      {
          //           ModelState.AddModelError("Description", "Description and Name should not be same !");
          //      }
          //      pointsOfInterestToUpdate.Name = UpdateDtp.Name;
          //      pointsOfInterestToUpdate.Description = UpdateDtp.Description;

          //      return NoContent();
          // }


          // Here We will write Detele Function

          [HttpDelete("{cityId}/PointsOfInterest/{id}")]
          public IActionResult DeletePointsOfInterest(int cityId, int Id)
          {
               var city = CitiesDataStore.Current.Citites.FirstOrDefault(pp =>pp.Id == cityId);
               if (city == null)
               {
                    return NotFound();
               }
               var DeletePointsOfInterest =
               city.PointsOfInterest.FirstOrDefault(pp =>pp.Id == Id);
               if (DeletePointsOfInterest == null)
               {
                    return NotFound();
               }
               city.PointsOfInterest.Remove(DeletePointsOfInterest);
               return NoContent();
          }
     }
}
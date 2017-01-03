using System;
using System.Collections.Generic;
using System.Linq;
using DemoApplication1.Data;
using DemoApplication1.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication1.Services
{
    public class CityInfo : ICityInfoRepository
     {
          private readonly ApplicationDbContext _context;
          public CityInfo(ApplicationDbContext context)
          {
               _context = context;
          }
          public IEnumerable<City> GetCities()
          {
               var city = _context.Cities.OrderBy(c => c.Name).ToList();
               return city;
          }

          public City GetCity(int cityId, bool IncludePointsOfInterest)
          {
               if (IncludePointsOfInterest)
               {
                    return _context.Cities.Include(c => c.PointsOfInterests).Where(c => c.Id == cityId).FirstOrDefault();
               }
               return _context.Cities.Where(c => c.Id == cityId).FirstOrDefault();
          }

          public PointsOfInterest GetPointsOfInterestByCity(int cityId, int pointsOfInterestId)
          {
           return   _context.PointsOfInterests.Where(c =>c.CityId == cityId && c.Id== pointsOfInterestId).FirstOrDefault();
          }

          public  IEnumerable<PointsOfInterest> GetPointsOfInterestForCity(int cityId)
          {
               return _context.PointsOfInterests.Where(c => c.CityId == cityId).ToList();
          }

      
    }
}
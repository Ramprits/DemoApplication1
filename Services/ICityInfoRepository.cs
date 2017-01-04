using System.Collections.Generic;
using DemoApplication1.Entities;

namespace DemoApplication1.Services
{
    public interface ICityInfoRepository
     {
          IEnumerable<City> GetCities();

          City GetCity(int cityId, bool IncludePointsOfInterest);

          PointsOfInterest GetPointsOfInterestByCity(int cityId, int pointsOfInterestId);

          IEnumerable<PointsOfInterest> GetPointsOfInterestForCity(int cityId);
     }
}
using System.Collections.Generic;

namespace DemoApplication1.Models
{
     public class CitiesDataStore
     {
          // Auto properity initializer syntax
          // C# 6 has this type of functionality
          public static CitiesDataStore Current { get; set; } =
          new CitiesDataStore();
          public ICollection<CityDto> Citites { get; set; }

          public CitiesDataStore()
          {
               Citites = new List<CityDto>()
            {
              new CityDto()
              {
                  Id =1,
                  Name = "New Yark City",
                  Description ="The one with that big park",
                  PointsOfInterest = new List<PointsOfInterestDto>()
                  {
                    new PointsOfInterestDto()
                    {
                      Id = 1,
                      Name = "Central park",
                      Description = "The most visited urban park in the united state"
                    },
                    new PointsOfInterestDto()
                    {
                      Id = 2,
                      Name = "Empire State building",
                      Description = "The most visited urban park in the united state ,Empire State building"
                    }
                  }
               } ,
                new CityDto()
              {
                  Id =2,
                  Name = "India",
                  Description ="The one with politics ",
                  PointsOfInterest = new List<PointsOfInterestDto>()
                  {
                    new PointsOfInterestDto()
                    {
                      Id = 1,
                      Name = "Empire State building, India",
                      Description = " India: The most visited urban park in the united state ,Empire State building"
                    }
                    ,
                     new PointsOfInterestDto()
                    {
                      Id = 2,
                      Name = "Empire State building, USA",
                      Description = "USA: India: The most visited urban park in the united state ,Empire State building"
                    },
                      new PointsOfInterestDto()
                    {
                      Id = 3,
                      Name = "Empire State building, USA 3",
                      Description = "USA 3: India: The most visited urban park in the united state ,Empire State building"
                    }

                  }

               }
               ,
                new CityDto()
                  {
                      Id =3,
                      Name = "Paris",
                      Description ="The one with big tower ",
                      PointsOfInterest = new List<PointsOfInterestDto>()
                      {
                        new PointsOfInterestDto()
                        {
                            Id = 1,
                            Name = "Empire State building, USA 3",
                            Description = "USA 3: India: The most visited urban park in the united state ,Empire State building"

                        },
                         new PointsOfInterestDto()
                        {
                            Id = 2,
                            Name = "Empire State building, USA 3",
                            Description = "USA 3: India: The most visited urban park in the united state ,Empire State building"

                        },
                         new PointsOfInterestDto()
                        {
                            Id = 3,
                            Name = "Empire State building, USA 3",
                            Description = "USA 3: India: The most visited urban park in the united state ,Empire State building"

                        },
                         new PointsOfInterestDto()
                        {
                            Id = 4,
                            Name = "Empire State building, USA 3",
                            Description = "USA 3: India: The most visited urban park in the united state ,Empire State building"

                        }
                      }
                  }
            };
          }
     }
}
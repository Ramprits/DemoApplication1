using System.ComponentModel.DataAnnotations;

namespace DemoApplication1.Models
{
     public class PointsOfInterestCreationDto
     {
          [Required]
          [MaxLength(20)]
          public string Name { get; set; }
          [Required]
          [MaxLength(250)]
          public string Description { get; set; }
     }
}
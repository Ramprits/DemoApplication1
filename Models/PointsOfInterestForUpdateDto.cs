using System.ComponentModel.DataAnnotations;

namespace DemoApplication1.Models
{
     public class PointsOfInterestForUpdateDto
     {
          [Required(ErrorMessage = "Please enter {0}")]
          [MaxLength(20)]
          public string Name { get; set; }
          public string Description { get; set; }
     }
}
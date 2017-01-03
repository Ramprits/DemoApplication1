using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApplication1.Entities
{
     public class PointsOfInterest
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }
          [Required]
          [MaxLengthAttribute(20)]
          public string Name { get; set; }
          public string Description { get; set; }

          [ForeignKeyAttribute("CityId")]
          public virtual City Cities { get; set; }
          public int CityId { get; set; }
          public static List<PointsOfInterest> Current { get; set; } =
          new List<PointsOfInterest>();
     }
}
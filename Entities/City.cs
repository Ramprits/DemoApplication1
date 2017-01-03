using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApplication1.Entities
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLengthAttribute(20)]
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<PointsOfInterest> PointsOfInterests { get; set; } =
        new List<PointsOfInterest>();

        public DateTime  CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
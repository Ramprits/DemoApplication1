namespace DemoApplication1.Models
{
    public class PointsOfInterestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual CityDto Cities { get; set; }
    }
}
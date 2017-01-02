using System;

namespace DemoApplication1.Models
{
     public class Employee
     {
          public int Id { get; set; }
          public string Name { get; set; }
          public string  Gender { get; set; }
          public string Address { get; set; }
          public string Email { get; set; }
          public string Mobile { get; set; }
          public string Image { get; set; }

          public DateTime? CreatedDate { get; set; }

          public Employee()
          {
              CreatedDate = DateTime.UtcNow;
          }
     }
}
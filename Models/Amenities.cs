using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Amenities
    {

        [Key]
        public int AmenitiesId { get; set; }
        public bool ElevatorFromAddress { get; set; }
        public bool ElevatorToAddress { get; set; }
        public bool FurnitureLiftFromAddress { get; set; }
        public bool FurnitureLiftToAddress { get; set; }

    }
}

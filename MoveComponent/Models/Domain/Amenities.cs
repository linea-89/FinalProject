using System.Reflection.Metadata;

namespace FinalProject.MoveComponent.Models.Domain
{
    public class Amenities
    {
        public int Id { get; set; } = 0;
        public bool ElevatorFromAddress { get; set; } = false;
        public bool ElevatorToAddress { get; set; } = false;
        public bool FurnitureLiftFromAddress { get; set; } = false;
        public bool FurnitureLiftToAddress { get; set; } = false;

        public int MoveId { get; set; } // Required foreign key property
        public Move Move { get; set; } = null!; // Required reference navigation to principal
    }
}

using FinalProject.Shared.ModelInterfaces;

namespace FinalProject.Models.MoveModels
{
    public class Amenities : IAmenities
    {
        public int Id { get; set; }
        public bool ElevatorFromAddress { get; set; } = false;
        public bool ElevatorToAddress { get; set; } = false;
        public bool FurnitureLiftFromAddress { get; set; } = false;
        public bool FurnitureLiftToAddress { get; set; } = false;

        public int MoveId { get; set; }
        public Move Move { get; set; } = null!;

        IMove IAmenities.Move
        {
            get => Move;
            set => Move = (Move)value;
        }
    }

}

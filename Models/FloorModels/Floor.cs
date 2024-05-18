using FinalProject.Shared.ModelInterfaces;
using FinalProject.Models.MoveModels;
using FinalProject.Models.RoomModels;

namespace FinalProject.Models.FloorModels
{
    public class Floor : IFloor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SortOrder { get; set; } = 0;

        public int MoveId { get; set; } // Required foreign key property
        public Move Move { get; set; } = null!; // Required reference navigation to principal

        public ICollection<Room> Rooms { get; set; } = new List<Room>();

        IMove IFloor.Move
        {
            get => Move;
            set => Move = (Move)value;
        }

        ICollection<IRoom> IFloor.Rooms
        {
            get => Rooms.Cast<IRoom>().ToList();
            set => Rooms = value.Cast<Room>().ToList();
        }

    }

}

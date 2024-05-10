namespace FinalProject.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int FloorId { get; set; } // Required foreign key property
        public Floor Floor { get; set; } = null!; // Required reference navigation to principal
        public ICollection<Room> Rooms { get; set; } = new List<Room>();

    }
}

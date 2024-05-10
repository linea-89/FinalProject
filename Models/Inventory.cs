namespace FinalProject.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int RoomId { get; set; }
        public float Volume { get; set; } = 0.0f;
        public bool Special { get; set; } = false;
        public bool Disassemble { get; set; } = false;
        public bool Assemble { get; set; } = false;

        //  public File Image { get; set; }

        public Wrapping Wrapping { get; set; } = null!;
        public Room Room { get; set; } = new Room();
        public bool NotIncluded { get; set; } = false;

    }
}


namespace FinalProject.Models
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int RoomId { get; set; }
        public float Volume { get; set; } = 0.0f;
        public bool Special { get; set; } = false;
        public bool Disassemble { get; set; } = false;
        public bool Assemble { get; set; } = false;

        //  public File Image { get; set; }

        public WrappingDto toBeWrapped { get; set; } = new WrappingDto();
        public bool NotIncluded { get; set; } = false;
    }
}

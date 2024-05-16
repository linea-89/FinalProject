using FinalProject.InventoryComponent.Models.Domain;

namespace FinalProject.Shared.Models.Domain
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Volume { get; set; } = 0.0f;
        public bool Special { get; set; } = false;
        public bool Disassemble { get; set; } = false;
        public bool Assemble { get; set; } = false;

        //  public File Image { get; set; }

        public Wrapping toBeWrapped { get; set; } = null!;
        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;
        public bool NotIncluded { get; set; } = false;

    }
}


using FinalProject.FloorComponent.Models.Domain;
using FinalProject.InventoryComponent.Models.Domain;

namespace FinalProject.RoomComponent.Models.Domain
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int FloorId { get; set; } // Required foreign key property
        public Floor Floor { get; set; } = null!; // Required reference navigation to principal

        public ICollection<Inventory> Inventories { get; } = new List<Inventory>();

    }
}

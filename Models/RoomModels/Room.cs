using FinalProject.Shared.ModelInterfaces;
using FinalProject.Models.FloorModels;
using FinalProject.Models.InventoryModels;

namespace FinalProject.Models.RoomModels
{
    public class Room : IRoom
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int FloorId { get; set; } // Required foreign key property
        public Floor Floor { get; set; } = null!; // Required reference navigation to principal

        public ICollection<Inventory> Inventories { get; } = new List<Inventory>();

        IFloor IRoom.Floor
        {
            get => Floor;
            set => Floor = (Floor)value;
        }

        ICollection<IInventory> IRoom.Inventories
        {
            get => Inventories.Cast<IInventory>().ToList();
        }

    }

}

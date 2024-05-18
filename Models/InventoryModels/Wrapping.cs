using FinalProject.Shared.ModelInterfaces;

namespace FinalProject.Models.InventoryModels
{
    public class Wrapping : IWrapping
    {
        public int Id { get; set; }
        public bool ShouldBeWrapped { get; set; } = false;
        public string Note { get; set; } = string.Empty;
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; } = null!;

        IInventory IWrapping.Inventory
        {
            get => Inventory;
            set => Inventory = (Inventory)value;
        }
    }

}

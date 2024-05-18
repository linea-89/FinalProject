using FinalProject.Shared.ModelInterfaces;

namespace FinalProject.Models.InventoryModels
{
    public class InventoryType : IInventoryType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Volume { get; set; } = 0.0f;

    }

}

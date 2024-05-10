using FinalProject.Models;

namespace FinalProject.Services.Inventory
{
    public interface IInventoryService
    {
        public Task<InventoryTypeDto> CreateInventoryType(InventoryTypeDto inventoryTypeDto);
    }
}

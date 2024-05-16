using FinalProject.InventoryComponent.Models.Domain;
using FinalProject.Shared.Models.Domain;

namespace FinalProject.Repositories.Interfaces
{
    public interface IInventoryRepository
    {
        public Task<Inventory> AddInventoryItemAsync(Inventory inventory);
        public Task<List<Inventory>> GetInventoryItemAsync(int roomId);
        public Task<InventoryType> CreateInventoryTypeAsync(InventoryType inventoryType);
        public Task<List<InventoryType>> GetInventoryTypesAsync();

    }
}

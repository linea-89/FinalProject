using FinalProject.Shared.ModelInterfaces;

namespace FinalProject.Shared.RepositoryInterfaces
{
    public interface IInventoryRepository
    {
        public Task<IInventory> AddInventoryItemAsync(IInventory inventory);
        public Task<List<IInventory>> GetInventoryItemsAsync(int roomId);
        public Task<IInventoryType> CreateInventoryTypeAsync(IInventoryType inventoryType);
        public Task<List<IInventoryType>> GetInventoryTypesAsync();

    }
}

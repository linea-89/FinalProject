using FinalProject.Data;
using FinalProject.Models.InventoryModels;
using FinalProject.Shared.ModelInterfaces;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models.MoveModels;
using FinalProject.Shared.RepositoryInterfaces;

namespace FinalProject.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly FinalProjectContext _context;
        public InventoryRepository(FinalProjectContext context)
        {
            _context = context;
        }

        public async Task<IInventory> AddInventoryItemAsync(IInventory inventory)
        {
            var inventoryEntity = inventory as Inventory;
            _ = _context.Inventory.Add(inventoryEntity);
            await _context.SaveChangesAsync();

            return inventoryEntity;
        }

        public async Task<List<IInventory>> GetInventoryItemsAsync(int roomId)
        {
            return await _context.Inventory
                .Where(x => x.RoomId == roomId)
                .ToListAsync<IInventory>();
        }

        public async Task<IInventoryType> CreateInventoryTypeAsync(IInventoryType inventoryType)
        {
            var inventoryEntity = inventoryType as InventoryType;
            _ = _context.InventoryTypes.Add(inventoryEntity);
            await _context.SaveChangesAsync();

            return inventoryEntity;
        }

        public async Task<List<IInventoryType>> GetInventoryTypesAsync()
        {
            return await _context.InventoryTypes.ToListAsync<IInventoryType>();
        }
    }
}

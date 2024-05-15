using FinalProject.Data;
using FinalProject.InventoryComponent.Models.Domain;
using FinalProject.Shared.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.InventoryComponent.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly FinalProjectContext _context;
        public InventoryRepository(FinalProjectContext context)
        {
            _context = context;
        }

        public async Task<Inventory> AddInventoryItemAsync(Inventory inventory)
        {
            _context.Inventory.Add(inventory);
            await _context.SaveChangesAsync();

            return inventory;
        }

        public async Task<List<Inventory>> GetInventoryItemAsync(int roomId)
        {
            return await _context.Inventory
                .Where(x => x.RoomId == roomId)
                .ToListAsync();
        }

        public async Task<InventoryType> CreateInventoryTypeAsync(InventoryType inventoryType)
        {
            _context.InventoryTypes.Add(inventoryType);
            await _context.SaveChangesAsync();

            return inventoryType;
        }

        public async Task<List<InventoryType>> GetInventoryTypesAsync()
        {
            return await _context.InventoryTypes.ToListAsync();
        }
    }
}

using FinalProject.InventoryComponent.Dto;
using FinalProject.Models.InventoryModels;
using FinalProject.Shared.ModelInterfaces;

namespace FinalProject.Shared.MapperInterfaces
{
    public interface IInventoryMapper
    {
        public Inventory MapAddedInventory(InventoryDto inventoryDto);
        public InventoryDto MapInventoryResponse(IInventory inventory);
        public List<InventoryDto> MapInventoryItemsResponse(List<IInventory> inventoryItems);
        public InventoryType MapCreatedInventoryType(InventoryTypeDto inventoryTypeDto);
        public InventoryTypeDto MapInventoryTypeResponse(IInventoryType inventoryType);
        public List<InventoryTypeDto> MapInventoryTypeRespons(List<IInventoryType> inventoryTypes);
    }
}
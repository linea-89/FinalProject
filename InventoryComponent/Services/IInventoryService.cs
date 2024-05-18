using FinalProject.InventoryComponent.Dto;

namespace FinalProject.InventoryComponent.Services
{
    public interface IInventoryService
    {
        public Task<InventoryDto> AddInventoryItem(InventoryDto inventoryDto);
        public Task<List<InventoryDto>> GetInventoryItems(int roomId);
        public Task<InventoryTypeDto> CreateInventoryType(InventoryTypeDto inventoryTypeDto);
        public Task<List<InventoryTypeDto>> GetInventoryTypes();


        /*
        public ActionResult<RoomDto> GetRoomById(int floorId, int id);
        */

    }
}

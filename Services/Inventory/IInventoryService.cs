using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Services.Inventory
{
    public interface IInventoryService
    {
        public Task<InventoryTypeDto> CreateInventoryType(InventoryTypeDto inventoryTypeDto);
        public ActionResult<List<InventoryTypeDto>> GetInventoryTypes();
        public Task<InventoryDto> AddInventoryItem(InventoryDto inventoryDto);

        
        public ActionResult<List<InventoryDto>> GetInventoryItem(int roomId);

        /*
        public ActionResult<RoomDto> GetRoomById(int floorId, int id);
        */

    }
}
